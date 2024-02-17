import { Time } from '@zos/sensor'

const timeSensor = new Time();

console.log("app service start");

AppService({
  onInit(e) {
    console.log(`app service onInit(${e})`);

    timeSensor.onPerMinute(() => {
        console.log(
        `${moduleName} time report: ${timeSensor.getHours()}:${timeSensor.getMinutes()}:${timeSensor.getSeconds()}`
      );
    });
  },
  onDestroy() {
    console.log("service on destroy invoke");
  },
});