import { BaseSideService } from "@zeppos/zml/base-side";

AppSideService(
  BaseSideService({
    onInit() {
      console.log('app side service invoke onInit')
    },
    onRun() {
        console.log('app side service invoke onRun')
    },
    onDestroy() {
        console.log('app side service invoke onDestroy')
    },
  }),
)