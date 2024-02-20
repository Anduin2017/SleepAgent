import { Sleep } from '@zos/sensor';
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
  console.log(`=== starting service: ${serviceFile} ===`);
  const result = appService.start({
    url: serviceFile,
    param: `service=${serviceFile}&action=start`,
    complete_func: (info) => {
      console.log(`=== startService result: ` + JSON.stringify(info) + " ===");
      hmUI.showToast({ text: `Service start: ${info.result}` });
    },
  });
}

Page(
  BasePage({
    state: {},
    build() {
      const vm = this;
      hmUI.createWidget(hmUI.widget.BUTTON, {
        ...FETCH_BUTTON,
        click_func: (button_widget) => {
          console.log("=== User clicked the button ===");
          permissionRequest(vm);
          this.fetchData();
        },
      });
    }
  })
);
