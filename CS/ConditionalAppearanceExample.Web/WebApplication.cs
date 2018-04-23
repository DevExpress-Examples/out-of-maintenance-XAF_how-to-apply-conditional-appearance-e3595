using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.Web;

namespace ConditionalAppearanceExample.Web {
   public partial class ConditionalAppearanceExampleAspNetApplication : WebApplication {
        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args) {
            args.ObjectSpaceProvider = new XPObjectSpaceProvider(args.ConnectionString, args.Connection);
        }
      private DevExpress.ExpressApp.SystemModule.SystemModule module1;
      private DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule module2;
      private ConditionalAppearanceExample.Module.ConditionalAppearanceExampleModule module3;
      private DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule module6;
      private DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule conditionalAppearanceModule1;
      private DevExpress.ExpressApp.Security.SecurityModule securityModule1;
      private ConditionalAppearanceExample.Module.Web.ConditionalAppearanceExampleWebModule conditionalAppearanceExampleWebModule1;
      private DevExpress.ExpressApp.Validation.ValidationModule module5;

      public ConditionalAppearanceExampleAspNetApplication() {
         InitializeComponent();
      }

      private void ConditionalAppearanceExampleAspNetApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
         e.Updater.Update();
         e.Handled = true;
      }

      private void InitializeComponent() {
         this.module1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
         this.module2 = new DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule();
         this.module3 = new ConditionalAppearanceExample.Module.ConditionalAppearanceExampleModule();
         this.module5 = new DevExpress.ExpressApp.Validation.ValidationModule();
         this.module6 = new DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule();
         this.conditionalAppearanceModule1 = new DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule();
         this.securityModule1 = new DevExpress.ExpressApp.Security.SecurityModule();
         this.conditionalAppearanceExampleWebModule1 = new ConditionalAppearanceExample.Module.Web.ConditionalAppearanceExampleWebModule();
         ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
         // 
         // module5
         // 
         this.module5.AllowValidationDetailsAccess = true;
         // 
         // ConditionalAppearanceExampleAspNetApplication
         // 
         this.ApplicationName = "ConditionalAppearanceExample";
         this.Modules.Add(this.module1);
         this.Modules.Add(this.module2);
         this.Modules.Add(this.module6);
         this.Modules.Add(this.conditionalAppearanceModule1);
         this.Modules.Add(this.securityModule1);
         this.Modules.Add(this.module3);
         this.Modules.Add(this.module5);
         this.Modules.Add(this.conditionalAppearanceExampleWebModule1);
         this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.ConditionalAppearanceExampleAspNetApplication_DatabaseVersionMismatch);
         ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

      }
   }
}
