import { Sleep, Vibrator } from '@zos/sensor';
import hmUI from "@zos/ui";
import * as appService from "@zos/app-service";
import { BasePage } from "@zeppos/zml/base-page";
import { queryPermission, requestPermission } from "@zos/app";
import {
  FETCH_BUTTON,
  FETCH_RESULT_TEXT,
} from "zosLoader:./index.[pf].layout.js";


let textWidget;
const permissions = ["device:os.bg_service"];
const serviceFile = "app-service/background_service";

function permissionRequest(vm) {
  const [result2] = queryPermission({
    permissions,
  });

  if (result2 === 0) {
    requestPermission({
      permissions,
      callback([result2]) {
        if (result2 === 2) {
          startTimeService(vm);
        }
      },
    });
  } else if (result2 === 2) {
    startTimeService(vm);
  }
}


function startTimeService(vm) {
  console.log(`=== start service: ${serviceFile} ===`);
  const result = appService.start({
    url: serviceFile,
    param: `service=${serviceFile}&action=start`,
    complete_func: (info) => {
      console.log(`startService result: ` + JSON.stringify(info));
      hmUI.showToast({ text: `start result: ${info.result}` });
    },
  });

  if (result) {
    console.log("startService result: ", result);
  }
}

Page(
  BasePage({
    state: {},
    build() {
      const vm = this;
      hmUI.createWidget(hmUI.widget.BUTTON, {
        ...FETCH_BUTTON,
        click_func: (button_widget) => {
          console.log("click_func");
          permissionRequest(vm);
          this.fetchData();
        },
      });
    },
    fetchData() {
      const vibrator = new Vibrator();
      vibrator.start();
      const sleep = new Sleep();
      sleep.updateInfo();
      const info = sleep.getInfo();
      const score = info.score;
      const isCurrentlySleeping = sleep.getSleepingStatus(); // 0 醒着，1 正在睡眠
      
      this
        .request({
        method: "GET_DATA",
        params: {
          score: score,
          isCurrentlySleeping: isCurrentlySleeping
        },
      })
        .then((data) => {
          const { result = {} } = data;
          const statusCode = result.status;
          //const text = JSON.stringify(result);
          const text = statusCode;

          if (!textWidget) {
            textWidget = hmUI.createWidget(hmUI.widget.TEXT, {
              ...FETCH_RESULT_TEXT,
              text,
            });
          } else {
            textWidget.setProperty(hmUI.prop.TEXT, text);
          }
        })
        .catch((res) => {});

      vibrator.stop();
    },
  })
);
