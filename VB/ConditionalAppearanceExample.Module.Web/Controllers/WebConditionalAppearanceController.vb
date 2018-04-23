Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports ConditionalAppearanceExample.Module.Controllers
Imports DevExpress.ExpressApp.ConditionalAppearance
Imports DevExpress.ExpressApp.Web.Editors
Imports DevExpress.ExpressApp.Web.Editors.ASPx
Imports System.Web.UI.WebControls
Imports System.Drawing

Namespace ConditionalAppearanceExample.Module.Web.Controllers
   Partial Public Class WebConditionalAppearanceController
       Inherits ConditionalAppearanceController

      Protected Overrides Sub CustomizeDisabledEditorsAppearance(ByVal e As ApplyAppearanceEventArgs)
         MyBase.CustomizeDisabledEditorsAppearance(e)
         Dim dxEditor As WebPropertyEditor = TryCast(e.Item, WebPropertyEditor)
         If dxEditor IsNot Nothing AndAlso dxEditor.Editor IsNot Nothing Then
            dxEditor.Editor.BorderStyle = BorderStyle.Dashed
            dxEditor.Editor.BackColor = Color.RosyBrown
         End If
      End Sub
   End Class
End Namespace
