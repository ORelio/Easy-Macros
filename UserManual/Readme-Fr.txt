                              =======================================================
                                  Easy Macros Version 1.3.1 - Par ORelio (c) 2013
                                        Site internet : http://microzoom.fr/
                              -------------------------------------------------------

===============
 Introduction
---------------

Merci d'avoir choisi Easy Macros ! Easy Macros est un logiciel gratuit vous permettant de d�finir facilement
des macros dans vos jeux et applications, et ce sans avoir besoin de disposer de mat�riel sophistiqu� !
N'importe quel clavier peut faire l'affaire ... :-)

Comment �a marche ? Easy Macros fonctionne sur un syst�me de scripts. Chaque script d�crit le fonctionnement
d'une macro : vous choisissez la touche qui d�clenche la macro et vous y associez des actions.

========================
 Maniement du logiciel
------------------------

Pour utiliser Easy Macros, il vous suffit d'extraire l'archive l� o� vous le d�sirez, puis de lancer
EasyMacros.exe : Une ic�ne apparait dans la zone de notification en bas � droite de la barre des t�ches.
Un clic droit sur cette ic�ne vous permet de quitter le logiciel ou acc�der � son interface principale.

Une fois l'interface principale d'Easy Macros ouverte, vous pouvez g�rer les macros d�j� pr�sentes, les
modifier ou cr�er une nouvelle macro en entrant des instructions dans la zone de texte puis en cliquant sur
Sauvegarder. Les macros sont sauvegard�es dans le dossier Macros et peuvent facilement �tre �chang�es avec
d'autres utilisateurs : Il suffit d'ajouter les fichiers re�us dans le dossier Macros.

Astuce : Pour lancer Easy Macros au d�marrage de Windows, placez un raccourci vers EasyMacros.exe dans
le dossier suivant : C:\Users\%username%\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup

==========================
 Comment cr�er une macro
--------------------------

Le squelette d'une macro se pr�sente comme ceci :

Macro K Application
Instruction
Instruction
Instruction
...

La premi�re ligne constitue les en-t�tes, les autres lignes les instructions : une instruction par ligne.

===============
 Les En-T�tes
---------------

Elles sont constitu�es de 3 informations :
 - Le type de macro
 - La touche d�clencheant la macro
 - L'application cible de la macro

Les types possibles de macro sont :
 - Macro : Cette macro se d�clenche avec le raccourci clavier Touche d'Activation + Touche de macro
 - SuperMacro : Cette macro se d�clenche juste en appuyant sur la touche de macro
 - MouseMacro : Cette macro se d�clenche avec la Touche d'Activation + un bouton de la souris
 - SuperMouseMacro : Cette macro se d�clenche avec le bouton de la souris sans touche d'activation
 - RewriteMacro : Cette macro se d�clenche via un raccourci clavier, en rempla�ant l'action normalement effectu�e
 - WinOpenMacro : Cette macro se d�clenche � l'ouverture d'une fen�tre r�pondant aux crit�res
 - StartupMacro : Cette macro se d�clenche au lancement du logiciel Easy Macros
 - IdleMacro : Cette macro se d�clenche au bout d'un certain temps d'inactivit�

La touche d�clenchant la macro peut �tre n'importe quelle touche du clavier, ou presque
 - Pour le moment, il n'est pas possible d'associer une macro avec une touche sp�ciale telle que Ctrl ou Alt.
 - Dans le cas d'une macro de souris, les touches possibles sont "Left", "Right", "Middle", "Previous", "Next".
 - Dans le cas d'une macro d'ouverture de fen�tre, mettez X. La touche indiqu�e est ignor�e mais n�cessaire.
 - Dans le cas d'une macro Idle, mettez IdleMacro X o� X est le temps d'inactivit� en secondes.
 - Les macros Idle ne se lancent pas si une application tourne en plein �cran (vid�o...)

Enfin, l'application cibl�e par la macro :
 - La macro ne sera d�clench�e que si la fen�tre au premier plan correspond au crit�re
 - Il vous suffit d'entrer un mot cl� apparaissant dans le titre de la fen�tre ou bien le nom de l'ex�cutable.
 - Par exemple, si dans le titre de la fen�tre il est inscrit "VLC Media Player", inscrivez "VLC".
 - Vous pouvez ne pas pr�ciser d'application cibl�e. Dans ce cas la macro fonctionnera partout.
 - Vous pouvez obtenir des informations sur la fen�tre de votre choix via l'option Infos de Fen�tre

Voici quelques exemples d'en-t�tes valides :
 - Macro X VLC
 - SuperMacro T explorer.exe
 - MouseMacro Right Firefox
 - SuperMouseMacro Right
 - RewriteMacro LAlt+LWin+Enter
 - WinOpenMacro X notepad.exe
 - IdleMacro 300
 - StartupMacro

===================
 Les instructions
-------------------

Une fois la macro d�clench�e, les instructions sont ex�cut�es une par une, de la premi�re � la derni�re ligne.
Les diff�rentes instructions possibles sont :

 - Key X : Simule un appui sur la touche X du clavier
 - KeyDown X : Simule un appui sur la touche, mais sans rel�cher celle-ci (Utile avec Shift, Alt ou Ctrl)
 - KeyUp X : Rel�che la touche appuy�e pr�c�demment via un KeyDown

 - Mouse X : Simule un appui sur le bouton de la souris : Left, Up, Right, Previous, Next
 - MouseDown X : Simule un appui sur le bouton mais sans rel�cher celui-ci
 - MouseUp X : Rel�che le bouton appuy� pr�c�demment via un MouseDown

 - Sleep n : Attend n millisecondes avant de passer � l'instruction suivante
 - Run monapplication.exe argument1 "argument 2" argument 3 etc : Lance un programme
 - Close monapplication.exe / Close Titre de la fen�tre : Ferme la fen�tre comme si on avait cliqu� sur la croix
 - Kill monapplication.exe : Tue le processus indiqu� (attention aux pertes de donn�es non sauvegard�es)

Pour les touches sp�ciales, c'est-�-dire celles ne produisant pas de caract�re quand on appuie dessus,
il vous suffit d'employer les mots cl�s suivants pour les d�signer dans votre script :

  Scroll, LShift, RShift, Shift, LCtrl, RCtrl, LAlt, RAlt, Alt, Back, Enter, Tab, Pause, Caps, Numlock,
  Escape, Space, End, Home, Left, Up, Right, Down, PrintScreen, Snapshot, Insert, Delete, WinLeft, WinRight

NB: Les touches pr�c�d�es par la lettre L ou R correspondent � la touche gauche (L) ou droite (R).
Ainsi LCtrl correspond � la touche "Ctrl" situ�e � gauche du clavier tandis que RCtrl correspond � celle de droite.

Un moyen simple de trouver le nom d'une touche est d'utiliser l'ardoise fournie dans le programme.
Une pression d'une touche affiche son nom dans l'ardoise.

Astuce: Vous pouvez pr�ciser des coordonn�es pour les actions Mouse, MouseDown, MouseUp.
Par exemple, "Mouse Left 600,420" effectuera un clic aux coordonn�es 600 (horizontal) et 420 (vertical) de l'�cran.

====================
 Exemple de script
--------------------

SuperMacro X VLC
Key Alt
Sleep 50
Key V
Key A

Cela effectue une capture d'�cran dans le lecteur VLC.

===========================
 Historique des versions
---------------------------

Version 1.0
 - Premi�re version d'Easy Macos
 - Permet d'associer des macros � une touche du clavier
 - Ic�ne dans la barre des t�ches, interface graphique
 - Types de macro : Macro, SuperMacro, MouseMacro, SuperMouseMacro
 - Instructions : Key, KeyDown, KeyUp, Sleep
 - Jeu complet de touches � utiliser dans les macros

Version 1.0.1
 - Correction du probl�me de saisie des accents circonflexes ou tr�mas

Version 1.1
 - Am�lior� l'interface graphique : R�organis�e, plus intuitive.
 - Am�lior� la d�tection du nom de l'�x�cutable de la fen�tre active
 - Aide au premier lancement ou quand Easy Macros est d�j� ouvert
 - Nouvelle macro WinOpenMacro : Se lance � l'apparition d'une fen�tre
 - Nouvelle commande Run pour les scripts de macros : lance un processus
 - Nouvelle commande Kill pour les scripts de macros : tue un processus
 - Nouvelle commande Close pour les scrips de macros : ferme une fen�tre
 - Possibilit� d'ouvrir rapidement le dossier contenant les macros
 - Possibilit� d'obtenir facilement les infos d'une fen�tre ouverte
 - Possibilit� d'associer une macro aux boutons Milieu, Pr�c�dent, Suivant de la souris
 - Correction du probl�me d'encodage des caract�res accentu�s dans un fichier de macro
 - Mise � jour de la DLL ActivityMonitor qui sert � surveiller les entr�es clavier

Version 1.2
 - Nouvelle macro StartupMacro : Se lance au d�marrage d'Easy Macros
 - Nouvelle macro IdleMacro : Se lance au bout d'un certain temps d'inactivit� de l'utilisateur
 - Nouvelles commandes Mouse, MouseDown, MouseUp pour les scripts de macros : simule la souris

Version 1.3
 - Possibilit� de d�clencher les macros avec n'importe quelle touche du clavier (ou presque)
 - Possibilit� de d�clencher les macros avec n'importe quelle combinaison de touches du clavier
 - Possibilit� d'attraper au vol la pression de touche ou combinaison de touche d�clenchante
   ex : SuperMacro E notepad.exe -> ex�cute la macro puis �crit 'e' dans le bloc notes
   ex : RewriteMacro E notepad.exe -> ex�cute la macro puis ignore/mange l'appui sur la touche E
 - Possibilit� d'activer ou d�sactiver une macro directement depuis l'interface
 - Ardoise facilitant la cr�ation de macro et de macros raccourci clavier

Version 1.3.1
 - Interface en anglais sur les syst�mes Windows non fran�ais
 - R�organisation du code source, traduction des commentaires en anglais

================
 Remerciements
----------------

Easy Macros a �t� con�u en utilisant les ressources suivantes :
 - UserActivityMonitor (DLL), par George Mamaladze, Article CodeProject n�7294
 - KeyboardEvents (Article), par Naren Neelamegam, Article CodeProject n�7305
 - GNOME Keyboard Shorcut (Ic�ne), par la team GNOME, http://gnome.org/
