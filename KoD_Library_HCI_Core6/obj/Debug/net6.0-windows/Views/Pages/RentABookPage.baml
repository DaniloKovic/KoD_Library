   M S B A M L   `   `   `  ????P  LKoD_Library_HCI_Core6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:KoD_Library_HCI_Core6.Views.Pages!KoD_Library_HCI_Core6.Views.Pages  5      5    /KoD_Library_HCI_Core6.Views.Pages.RentABookPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:KoD_Library_HCI_Core6.Views.Pages     5        N? Title$  RentABookPage??5	       ? 	Resources 5
       ?? 
TargetType ?? Property ?? Value(  "System.Windows.Controls.DatePicker??%  '??       '?? 3    '?? ?    '?? X    '  ?    ?? 5   
   " ??6   .?5      ??  ? ??$ 6q?60   ?? 5       ? ??
 ?   ?6-   ?? 5       ? ??
 ?????6,   ?? 5       ? ??$ 28??6'   ?? 5       ? ??$ 28??6&   ?? 5       ?@d?	IsChecked$ FalseY?6*   ?? 5       ? {?$ False??6*   5      ?? 5   
   " ??6   .?5      ??  ? ??$ 4q?60   ?? 5       ? ??$ 48??6'   ?? 5       ? ??$	 260??6&   ?? 5       ? ??$ 24(?6)   5      ?? 5   
   " ??6   .?5      ??  ? ??$	 260??6&   64   ?? 5        ? ??$ 4q?60   5!      ?? 5"   
   " ??6   .?5#      ??  ? ??$ 4q?60   5$      ?? 5%   
   "  6   .?5&      ??  ? ??$ 4q?60   5'      5(      .??5)      ? .+?5*   
   ?? -   5         ??Name$ gbRentABook??5*      $??Iznajmljivanje knjige??6)   $??24(?6H   $??10,10,10,10q?6V   $??3q?6k   
???   ?.??5,      ]? .+?5-      ?? -   5         ??Name$ spIznajmljivanjeInfo??5-      $??20,10,10,10q?6;   .+?5.      ??  ?? Orientation$ Vertical=?6!   $??0,10,0,0q?68   .+?5/      ?? $ 
Horizontal=?6%   $??0,10,0,0q?6>   .+?50      ?? -   5         ??Name$ lbNazivKnjige??50   $   .??6;   Naziv Knjige:6J   ?? 51      -   5        	 ??Name$	 tbKnjiga??51   &   
 ?? 
IsReadOnly$

 True??68   $	??588??6J   6X   52      ?? 53      -   5        $ spBookFilter??53   %   $ 
Horizontal=?6;   $??0,10,0,0q?6T   .+?54      ?? -   5        $	 tbBookFilter??54   &   $	??200??6<   $??	145,0,0,0q?6H   6]   ?? 55      -   5         ??Name$ 	btnFilter??55   %   $??48??68   $??5,0,0,0q?6C   .??56   "   ?? $`??ZC:\Users\DaK\source\repos\KoD_Library_HCI_Core6\KoD_Library_HCI_Core6\images\magnifier.png??6(   57      ?? 58      -   5         ??Name$ cbFilterResult??58   '   $	??330??6?   $??5,0,0,0q?6K   6?   59      ?? 5:      $ 
Horizontal=?6%   $??0,10,0,0q?6>   .+?5;      ?? -	   5        $ lbKorisnickoIme??5;   $   .??6=   	Korisnik:6H   ?? 5<      -
   5        $ cbKorisnici??5<   '   $	??300??6<    ?? SelectedIndex$ 0??6H    ?? IsTextSearchEnabled$
 True??6Z    ?? 
IsEditable$
 True??6u   6?   5=      ?? 5>      $ 
Horizontal=?6%   $??0,15,0,0q?6>   .+?5?      ?? -   5        $ lbDatumIznajmljivanja??5?   $   .??6C   Datum iznajmljivanja:6Z     5@      -   5          Name$ dpDatumIznajmljivanja??5@   )      SelectedDateFormat$ Short=?6H   6e   5A      ?? 5B      $ 
Horizontal=?6%   $??0,10,0,0q?6>   .+?5C      ?? -   5        $ lbDatumVracanja??5C   $   .??6=   Datum vraćanja:6N     5D      -   5        $ dpDatumVracanja??5D   )   $ Short=?6B   6_   5E      ?? 5F      $ 
Horizontal=?6%   $??0,10,0,0q?6>   .+?5G      ?? -   5        $ lbVracenaKnjjiga??5G   $   .??6>   Da li je vraćena:6Q   ?? 5H      -   5         ??Name$ 
chbVracena??5H   '   6>   5I      ?? 5J      $??0,25,0,0q?6%   .+?5K      ?? -   5        $ btnIznajmiKnjigu??5K   %   $	??360??6?   $
??Left=?6K   .??6?   Potvrdi iznajmljivanje knjige6?   5L      5M      5N      ?? 5O      $??Right=?6   $	??Top=?69   .+?5P      ?? $^??XC:\Users\DaK\source\repos\KoD_Library_HCI_Core6\KoD_Library_HCI_Core6\images\newBook.png??6   $	??130??6~   $	??130??6?   $??25q?6?   5Q      5R      5T      5U      5V      