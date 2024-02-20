using System.Net;
using System.Text;
using Aiursoft.CSTools.Tools;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Aiursoft.WebTools.Extends;

namespace Anduin.SleepAgent.WebServer.Tests;

[TestClass]
public class BasicTests
{
    private readonly string _endpointUrl;
    private readonly int _port;
    private readonly HttpClient _http;
    private IHost? _server;

    public BasicTests()
    {
        _port = Network.GetAvailablePort();
        _endpointUrl = $"http://localhost:{_port}";
        _http = new HttpClient();
    }

    [TestInitialize]
    public async Task CreateServer()
    {
        _server = App<Startup>(Array.Empty<string>(), port: _port);
        await _server.StartAsync();
    }

    [TestCleanup]
    public async Task CleanServer()
    {
        if (_server == null) return;
        await _server.StopAsync();
        _server.Dispose();
    }

    [TestMethod]
    [DataRow("/")]
    public async Task GetHome(string url)
    {
        var response = await _http.GetAsync(_endpointUrl + url);
        response.EnsureSuccessStatusCode(); // Status Code 200-299
    }

    [TestMethod]
    public async Task TestDoc()
    {
        var response = await _http.GetAsync(_endpointUrl + "/api/metrics");
        response.EnsureSuccessStatusCode(); // Status Code 200-299
    }

    [TestMethod]
    public async Task TestAll()
    {
        // Post a json object to /api/metrics/send?nick-name=aaaaa
        var postResponse = await _http.PostAsync(_endpointUrl + "/api/metrics/send?nick-name=aaaaa", new StringContent("{}", Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, postResponse.StatusCode);
        
        var response = await _http.GetAsync(_endpointUrl + "/api/metrics/all");
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        var responseMessage = await response.Content.ReadAsStringAsync();
        Assert.AreEqual("[\"aaaaa\"]", responseMessage);
    }
    
    [TestMethod]
    public async Task TestQuery()
    {
        // Post a json object to /api/metrics/send?nick-name=aaaaa
        var postResponse = await _http.PostAsync(_endpointUrl + "/api/metrics/send?nick-name=aaaaa", new StringContent("{}", Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, postResponse.StatusCode);

        var response = await _http.GetAsync(_endpointUrl + "/api/metrics/query?nick-name=aaaaa");
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        var responseMessage = await response.Content.ReadAsStringAsync();
        Assert.AreEqual("{}", responseMessage);
    }

}