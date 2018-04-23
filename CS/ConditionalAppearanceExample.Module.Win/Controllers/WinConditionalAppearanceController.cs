using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

using DevExpress.ExpressApp.ConditionalAppearance;
using ConditionalAppearanceExample.Module.Controllers;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraEditors.Controls;
using System.Drawing;

namespace ConditionalAppearanceExample.Module.Win.Controllers {
   public partial class WinConditionalAppearanceController : ConditionalAppearanceController {

      protected override void CustomizeDisabledEditorsAppearance(ApplyAppearanceEventArgs e) {
         base.CustomizeDisabledEditorsAppearance(e);
         DXPropertyEditor dxEditor = e.Item as DXPropertyEditor;
         if (dxEditor != null && dxEditor.Control != null) {
            dxEditor.Control.Properties.Appearance.BackColor = Color.RosyBrown;
            dxEditor.Control.Properties.BorderStyle = BorderStyles.Simple;            
         }
      }
   }
}
