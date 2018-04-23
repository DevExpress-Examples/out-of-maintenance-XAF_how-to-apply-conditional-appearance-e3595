using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

using DevExpress.ExpressApp.ConditionalAppearance;
using ConditionalAppearanceExample.Module.Business_Objects;
using DevExpress.ExpressApp.Editors;

namespace ConditionalAppearanceExample.Module.Controllers {
   public partial class ConditionalAppearanceController : ViewController {
      public ConditionalAppearanceController() {
         InitializeComponent();
         RegisterActions(components);
         TargetObjectType = typeof(Product);
      }
      private AppearanceController appearanceController;
      protected override void OnActivated() {
         base.OnActivated();
         appearanceController = Frame.GetController<AppearanceController>();
         if (appearanceController != null) {
            appearanceController.CustomApplyAppearance += new EventHandler<ApplyAppearanceEventArgs>(appearanceController_CustomApplyAppearance);
            appearanceController.AppearanceApplied += new EventHandler<ApplyAppearanceEventArgs>(appearanceController_AppearanceApplied);
         }
      }

      void appearanceController_AppearanceApplied(object sender, ApplyAppearanceEventArgs e) {
         if ((View is ListView) && (e.ItemType == AppearanceItemType.ViewItem.ToString()) && (e.ItemName == "Category") && (e.ContextObjects.Length > 0)) {
            if (View.SelectedObjects.Contains(e.ContextObjects[0])) {
               IAppearanceFormat formattedItem = e.Item as IAppearanceFormat;
               if (formattedItem != null) {
                  //Reset the font color of the Category property for selected objects
                  formattedItem.ResetFontColor();
               }
            }
         }
      }

      protected virtual void CustomizeDisabledEditorsAppearance(ApplyAppearanceEventArgs e) {      
      }

      void appearanceController_CustomApplyAppearance(object sender, ApplyAppearanceEventArgs e) {
         
         if (e.AppearanceObject.Enabled == false) {
            //Customize the appearance of the editors disabled by a rule 
            CustomizeDisabledEditorsAppearance(e);
            //Cancel other possible conditional appearance changes,
            //applying only the rule that disables the item
            e.Handled = true;
         }
      }
      protected override void OnDeactivated() {
         if (appearanceController != null) {
            appearanceController.CustomApplyAppearance -= new EventHandler<ApplyAppearanceEventArgs>(appearanceController_CustomApplyAppearance);
            appearanceController.AppearanceApplied -= new EventHandler<ApplyAppearanceEventArgs>(appearanceController_AppearanceApplied);
         }
         base.OnDeactivated();
      }
   }
}
