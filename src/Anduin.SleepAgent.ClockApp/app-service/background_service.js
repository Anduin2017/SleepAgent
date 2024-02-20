import * as notificationMgr from "@zos/notification";
import { Time } from '@zos/sensor'
import { BasePage } from "@zeppos/zml/base-page";
import { HeartRate, Battery, BloodOxygen, Calorie, Distance, FatBurning, Pai, Sleep, Stand, Step, Stress, Wear } from "@zos/sensor";
import { getProfile } from '@zos/user'
import { getDeviceInfo } from '@zos/device'

const timeSensor = new Time();
const debugging = false;
const endPoint = "http://lab:12222/api/metrics/send"

// Send a notification
function sendNotification(vm) {

  const nickName = getProfile().nickName;
  const deviceInfo = getDeviceInfo();
  const heartRate = new HeartRate();
  const battery = new Battery();
  const bloodOxygen = new BloodOxygen();
  const calorie = new Calorie();
  const distance = new Distance();
  const fatBurning = new FatBurning();
  const pai = new Pai();
  const sleep = new Sleep();
  const stand = new Stand();
  const step = new Step();
  const stress = new Stress();
  const wear = new Wear();

  sleep.updateInfo();

  const reqBody = {
    user: getProfile(),
    device: deviceInfo,
    heartRateLast: heartRate.getLast(),
    heartRateResting: heartRate.getResting(),
    heartRateSummary: heartRate.getDailySummary(),
    battery: battery.getCurrent(),
    bloodOxygen: bloodOxygen.getCurrent(),
    bloodOxygenLastFewHour: bloodOxygen.getLastFewHour(),
    calorie: calorie.getCurrent(),
    calorieT: calorie.getTarget(),
    distance: distance.getCurrent(),
    fatBurning: fatBurning.getCurrent(),
    fatBurningT: fatBurning.getTarget(),
    paiDay: pai.getToday(),
    paiWeek: pai.getTotal(),
    sleepInfo: sleep.getInfo(),
    sleepStgList: sleep.getStageConstantObj(),
    SleepingStatus: sleep.getSleepingStatus(),
    stands: stand.getCurrent(),
    standsT: stand.getTarget(),
    steps: step.getCurrent(),
    stepsT: step.getTarget(),
    stress: stress.getCurrent(),
    isWearing: wear.getStatus(),
  };

  vm.httpRequest({
    method: 'POST',
    url: endPoint + "?nick-name=" + nickName,
    body: JSON.stringify(reqBody),
    headers: {
      'Content-Type': 'application/json'
    }
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
        sendNotification(this);
      });
    }
}));
