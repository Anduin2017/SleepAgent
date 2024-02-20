import * as notificationMgr from "@zos/notification";
import { Time } from '@zos/sensor'
import { Sleep } from '@zos/sensor';

const timeSensor = new Time();

// Send a notification
function sendNotification() {

  const sleep = new Sleep();
  sleep.updateInfo();
  const info = sleep.getInfo();
  const score = info.score;
  const isCurrentlySleeping = sleep.getSleepingStatus(); // 0 醒着，1 正在睡眠

  notificationMgr.notify({
    title: "Agent Service",
    content: isCurrentlySleeping ? "Sleeping" : "Waking" + " score: " + score,
    actions: []
  });
}

AppService({
  onInit(_) {
    timeSensor.onPerMinute(() => {
      sendNotification();
    });
  },
});