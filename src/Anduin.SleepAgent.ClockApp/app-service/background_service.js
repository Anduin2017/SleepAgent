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
function sendMetrics(vm) {

  const startTime = new Date().getTime();
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
    recordTime: startTime,
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
    sleepingStatus: sleep.getSleepingStatus(),
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
    const endTime = new Date().getTime();
    const duration = endTime - startTime;
    console.log("Request status: " + status);
    if (debugging) {
      notificationMgr.notify({
        title: "Agent Service",
        content: "Request status: " + status + " in " + duration,
        actions: []
      });
    }
  }).catch((error) => {
    const endTime = new Date().getTime();
    const duration = endTime - startTime;
    console.log("Request error: " + error);
    if (debugging) {
      notificationMgr.notify({
        title: "Agent Service",
        content: "Request error: " + error + " in " + duration,
        actions: []
      });
    }
  });
}

AppService(
  BasePage({
    onInit(_) {
      timeSensor.onPerMinute(() => {

        // Run every 5 minutes
        // var shouldRun = timeSensor.getMinutes() % 5 == 0;
        // if (!shouldRun) return;

        sendMetrics(this);
      });
    }
}));
