using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using ConditionalAppearanceExample.Module.Controllers;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Web.Editors;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using System.Web.UI.WebControls;
using System.Drawing;

namespace ConditionalAppearanceExample.Module.Web.Controllers {
   public partial class WebConditionalAppearanceController : ConditionalAppearanceController {

      protected override void CustomizeDisabledEditorsAppearance(ApplyAppearanceEventArgs e) {
         base.CustomizeDisabledEditorsAppearance(e);
         WebPropertyEditor dxEditor = e.Item as WebPropertyEditor;
         if (dxEditor != null && dxEditor.Editor != null) {
            dxEditor.Editor.BorderStyle = BorderStyle.Dashed;
            dxEditor.Editor.BackColor = Color.RosyBrown;
         }
      }
   }
}
