import * as notificationMgr from "@zos/notification";
import { Time } from '@zos/sensor'
import { Sleep } from '@zos/sensor';
import { BasePage } from "@zeppos/zml/base-page";

const timeSensor = new Time();
const debugging = true;

// Send a notification
function sendNotification(vm) {

  const sleep = new Sleep();
  sleep.updateInfo();
  const info = sleep.getInfo();
  const score = info.score;
  const isCurrentlySleeping = sleep.getSleepingStatus(); // 0 醒着，1 正在睡眠

  if (debugging) {
    console.log("Sleeping: " + isCurrentlySleeping + " score: " + score);
    notificationMgr.notify({
      title: "Agent Service",
      content: isCurrentlySleeping ? "Sleeping" : "Waking" + " score: " + score,
      actions: []
    });
  }
  vm.httpRequest({
    method: 'POST',
    url: 'https://www.aiursoft.cn/api/metrics/',
    body: reqBody
  })
  .then((result) => {
    const status = result.status;
    if (debugging) {
      console.log("Request status: " + status);
      notificationMgr.notify({
        title: "Agent Service",
        content: "Request status: " + status,
        actions: []
      });
    }
  }).catch((error) => {
    if (debugging) {
      console.log("Request error: " + error);
      notificationMgr.notify({
        title: "Agent Service",
        content: "Request error: " + error,
        actions: []
      });
    }
  });
}

AppService(
  BasePage({
    onInit(_) {
      timeSensor.onPerMinute(() => {
        const vm = this;
        sendNotification(vm);
      });
    }
}));
