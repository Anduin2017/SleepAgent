# This is a modified Grafana image that includes our customised configuration file

FROM hub.aiursoft.cn/grafana/grafana
COPY ./datASources /etc/grafana/provisioning/datASources
COPY ./dAShboards /etc/grafana/provisioning/dAShboards
COPY ./dAShboardJson /var/lib/grafana/dAShboards