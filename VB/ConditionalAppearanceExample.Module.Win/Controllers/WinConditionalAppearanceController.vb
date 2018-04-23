Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Imports DevExpress.ExpressApp.ConditionalAppearance
Imports ConditionalAppearanceExample.Module.Controllers
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.XtraEditors.Controls
Imports System.Drawing

Namespace ConditionalAppearanceExample.Module.Win.Controllers
   Partial Public Class WinConditionalAppearanceController
       Inherits ConditionalAppearanceController

      Protected Overrides Sub CustomizeDisabledEditorsAppearance(ByVal e As ApplyAppearanceEventArgs)
         MyBase.CustomizeDisabledEditorsAppearance(e)
         Dim dxEditor As DXPropertyEditor = TryCast(e.Item, DXPropertyEditor)
         If dxEditor IsNot Nothing AndAlso dxEditor.Control IsNot Nothing Then
            dxEditor.Control.Properties.Appearance.BackColor = Color.RosyBrown
            dxEditor.Control.Properties.BorderStyle = BorderStyles.Simple
         End If
      End Sub
   End Class
End Namespace
