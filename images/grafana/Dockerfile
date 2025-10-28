# This is a modified Grafana image that includes our customised configuration file

FROM hub.aiursoft.com/grafana/grafana
COPY ./datasources /etc/grafana/provisioning/datasources
COPY ./dashboards /etc/grafana/provisioning/dashboards
COPY ./dashboardJson /var/lib/grafana/dashboards