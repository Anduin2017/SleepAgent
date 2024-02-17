import * as hmUI from "@zos/ui";
import { Sleep } from '@zos/sensor';
import { Vibrator } from '@zos/sensor'
import { BasePage } from "@zeppos/zml/base-page";
import {
  FETCH_BUTTON,
  FETCH_RESULT_TEXT,
} from "zosLoader:./index.[pf].layout.js";


let textWidget;
Page(
  BasePage({
    state: {},
    build() {
      hmUI.createWidget(hmUI.widget.BUTTON, {
        ...FETCH_BUTTON,
        click_func: (button_widget) => {
          console.log("click_func");
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
