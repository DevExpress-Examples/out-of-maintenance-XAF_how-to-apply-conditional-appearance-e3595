using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using DevExpress.ExpressApp;

namespace ConditionalAppearanceExample.Module.Win {
   [ToolboxItemFilter("Xaf.Platform.Win")]
   public sealed partial class ConditionalAppearanceExampleWindowsFormsModule : ModuleBase {
      public ConditionalAppearanceExampleWindowsFormsModule() {
         InitializeComponent();
      }
   }
}
