import { BaseSideService } from "@zeppos/zml/base-side";

async function fetchData(rsp, params) {
  try {

    console.log("=====>,", JSON.stringify(params));
    const response = await fetch({
      url: 'https://www.aiursoft.cn/api/sleepMetrics',
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(params),
    })
    var json = JSON.stringify(response);
    console.log("<=====,", json);

    rsp(null, {
      result: response,
    });
  } catch (error) {
    rsp(null, {
      result: "response",
    });
  }
};

AppSideService(
  BaseSideService({
    onInit() {},

    onRequest(req, rsp) {
      if (req.method === "GET_DATA") {
        fetchData(rsp, req.params);
      }
    },

    onRun() {},

    onDestroy() {},
  })
);
