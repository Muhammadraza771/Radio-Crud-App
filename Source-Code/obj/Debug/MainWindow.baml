   M S B A M L   `   `   `  ????W  SB_Validation_ByDataErrorInfo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:B_Validation_ByDataErrorInfoB_Validation_ByDataErrorInfo  5   	   -    'B_Validation_ByDataErrorInfo.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:B_Validation_ByDataErrorInfo     5   	     ? Title$  Majid Khadim Ali??5   	   $	??450??6"   $	??800??6/    ? WindowStartupLocation$ CenterScreen=?6;    ? DataContext 5	      1   +B_Validation_ByDataErrorInfo.RegistrationVM  5
   
   .??5      ? $	??100q?6    ? ColumnDefinitions 5   
   ?? 5      $??184.338 ?6   ?? 5      $??33.662 ?6   ?? 5      $	??150 ?6   ?? 5      $	??25* ?6   ?? 5      $??7* ?6    ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $??* ?6   .+?5"   
   ?? $??0??6   $??0??6   $
??Bold"?6.   $??2??6@   .??6T   Enter Admin Credentials6m   ?? 5%   
   $??1??6   $??0??6   $??	150,5,5,5q?6-   $??2??6@   .??6T   
Username6^   ?? 5&   
   -   5         ??Name$ usernameTextbox??5&      $??1??6+   $??2??68   $??	5,5,10,10q?6H   ??6[   ?? *
Username+ ?? ValidatesOnDataErrors .  ?? UpdateSourceTrigger$ PropertyChanged=? ? ToolTip 5(      ?? *ErrorCollection[Username]+?? 5*   
   $??2??6   $??0??6   $??	150,5,5,5q?6-   $??2??6@   .??6T   
Password6^   ?? 5+   
   -   5        $ passwordTextbox??5+      $??2??6+   $??2??68   $??	5,5,10,10q?6H   ??6[   ?? *
Password+ . $ PropertyChanged=? 5-      ?? *ErrorCollection[Password]+?? 50   
   -   5        	 ??Name$	 loginbutton??50      $??30??6&   $??70??62   $??	68,5,12,5q?6=   $??2??6P   $??3??6`   ???	#FFF5EDED???	#FFF9EEEE.??6?   Login6?   ? 51   
   -   5        
 ?Name$
 
navbarGrid??51      $??65??6#   $??-100,-98,-99,0q?6/   $	??Top=?6G    J? RenderTransformOrigin$ 0.258,0.574&?6_   $??5??6?   ???	#FF2784B9$y?Visible=?6?   53      54      