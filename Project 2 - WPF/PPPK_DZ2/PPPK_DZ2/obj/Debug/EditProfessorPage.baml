   M S B A M L   `   `   `  ????C  ?PPPK_DZ2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PPPK_DZ2PPPK_DZ2  5           PPPK_DZ2.EditProfessorPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:PPPK_DZ2     5        N? Title$  EditProfessorPage??5	      .??5      ? -   5         ?Name$ GridContainer??5   	      GradientBackground#??[  5   	   .+?5   
   ?? -   5         ??Name$ BtnBack??5      $??50??5      $??50??5      
?????? 
?????? $	??Top=?5      $
??Left=?6%   .??5      ?? $??/Assets/back.png??6   5      ?? 5   
   $
??Left=?5      $	??Top=?6(   $	??133??5      $??First name:??6   
???????$??20(?6B   $??
53,134,0,0q?6P   ?? 5   
   -   5         ??Name$ TbFirstName??5      $
??Left=?5!      $	??Top=?6(   $	??215??5"      $??20??6   $??185,142,0,0q?5#      ??5       ?? *	FirstName+5#      ?? 5$   
   $
??Left=?5%      $	??Top=?6(   $	??133??5&      $??
Last name:??6   
???????$??20(?6A   $??
53,176,0,0q?6O   ?? 5'   
   -   5        $ 
TbLastName??5(      $
??Left=?5*      $	??Top=?6(   $	??215??5+      $??20??6   $??185,184,0,0q?5,      ??5)      ?? *
LastName+5,      ?? 5-   
   $
??Left=?5.      $	??Top=?6(   $	??133??5/      $??Email:??6   
???????$??20(?6=   $??
53,213,0,0q?6K   ?? 50   
   -   5        $ TbEmail??51      
 ? Tag$ Email??52      $
??Left=?54      $	??Top=?6(   $	??215??55      $??20??6   $??185,223,0,0q?56      ??53      ?? *Email+56      ?? 59   
   -   5        $ 	BtnCommit??5:      $??Commit Changes??5;      
???????
??? ???$??Bottom=?5?      $??30??5@      $??185,0,400,165q?6   ?? 5B   
   -   5         ??Name$ 	LvCourses??5C       ?? AlternationCount$ 2??6    $
??Left=?5D      $	??Top=?6(   $	??151??5E      $	??300??6   $??456,134,0,0q?6&   ??5F      ?? 5G       ?? 
TargetType" ??6   .?5H      ??  ?? Property ? ??	 ?? Value
	 ??ح?63   
 ?? Triggers
 5I      P? 5J       P? Property ?@??AlternationIndex P? Value$ 1??6G   . ?5K      ??  ? ??
	 ?????6;   5L      ]? 5M       ]? 
Conditions 5N      ?? 5O   "    ?? Property ?@??
IsSelected ?? Value . 6B   ./?5Q      ??  ? ??
	 ???_?6;   5R      5T       ?? View 5V      ?? 5W      .P?5X      ??  ?? Width$	 200??5Y      $??Course name??5Z       ?? DisplayMemberBinding 5[      ?? *Name+?? 5\      $	 100??5]      $
??ECTS??5^       5_      ?? *ECTS+5`      5b      ?? 5c   
   $
??Left=?6   $??Bottom=?6+   $??Choose a course:??5d      $	??105??6(   $??25??64   
???????$??Arial)?6S   $??456,0,0,377q?6f   ?? 5e   
   -   5         ??Name$ 	CbCourses??5e      $??456,89,157,339q?6&   ?? 5f   
   -	   5        $ BtnAddCourse??5g      $	??Add??5h      
???????
??? ? ?$??10(?5l      $??Bottom=?5m      $??20??5n      $??660,0,44,339q?6   ?? 5o   
   -
   5        $ BtnRemoveCourse??5p      $??Remove??5q      
???????
??? E??$??10(?5u      $??Bottom=?5v      $??20??5w      $??660,0,44,129q?6   5|      5}      