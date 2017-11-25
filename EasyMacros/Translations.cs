using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace EasyMacros
{
    /// <summary>
    /// Allows to get the whole app in different languages
    /// </summary>
    public static class Translations
    {
        private static Dictionary<string, string> translations;

        /// <summary>
        /// Return a tranlation for the requested text
        /// </summary>
        /// <param name="msg_name">text identifier</param>
        /// <returns>returns translation for this identifier</returns>
        public static string Get(string msg_name)
        {
            if (translations.ContainsKey(msg_name))
                return translations[msg_name];

            return msg_name.ToUpper();
        }

        /// <summary>
        /// Initialize translations to French or English depending on system language.
        /// English is the default for all unknown system languages.
        /// Other translations may be added in this function.
        /// </summary>
        static Translations()
        {
            translations = new Dictionary<string, string>();

            if (CultureInfo.CurrentCulture.ThreeLetterISOLanguageName == "fra")
            {
                translations["about"] = "A Propos";
                translations["about_description"] = "Ce programme vous permet de définir facilement des macros dans vos différents jeux et applications.";
                translations["about_readme_file"] = "Readme-Fr.txt";
                translations["about_readme_file_not_found_text"] = "Le fichier d'aide {0} est introuvable !";
                translations["about_readme_file_not_found_title"] = "Fichier manquant";
                translations["about_text"] = Program.Name + " v" + Program.Version + " - par ORelio";
                translations["about_text_year"] = Program.Name + " v" + Program.Version + " - © " + Program.Year + " ORelio";
                translations["about_title"] = Program.Name + " v" + Program.Version;
                translations["about_title_dialog"] = "A propos d'" + Program.Name;
                translations["about_website"] = "Site internet : http://microzoom.fr/";
                translations["activate"] = "Activation";
                translations["activate_key_changed"] = "La touche d'activation a été correctement définie.";
                translations["activate_key_instructions"] = "Cliquez sur OK puis appuyez sur la touche de votre choix.";
                translations["activate_key_instructions_title"] = "Définition de la touche";
                translations["activate_key_prompt"] = "La combinaison Touche d'activation + Touche de macro sert à activer les macros standard. Souhaitez-vous changer la touche d'activation ?";
                translations["activate_key_title"] = "Touche d'Activation";
                translations["already_running"] = Program.Name + " est déjà en cours d'éxécution.\nCliquez sur l'icône dans zone de notification pour y accéder.";
                translations["clear"] = "Vider";
                translations["close"] = "Fermer";
                translations["close_this_menu"] = "Fermer ce menu";
                translations["copy"] = "Copier";
                translations["delete"] = "Supprimer";
                translations["delete_confirm"] = "Voulez-vous supprimer définitivement la macro\n{0} ?\nElle risque d'être perdue pour longtemps !";
                translations["delete_title"] = "Supprimer une macro";
                translations["disable"] = "Désactiver";
                translations["enable"] = "Activer";
                translations["exit"] = "Quitter";
                translations["explorer"] = "Explorateur";
                translations["help_file"] = "Fich. Aide";
                translations["info_instructions"] = "Placez-vous sur la fenêtre de votre choix et appuyez sur la touche d'activation pour obtenir les informations la concernant.";
                translations["info_title"] = "Informations sur une fenêtre";
                translations["macro"] = "Macro";
                translations["macro_definitions"] = "Définitions de Macros";
                translations["macro_editor"] = "Editeur de Macros";
                translations["minimize"] = "Réduire";
                translations["new"] = "Nouveau";
                translations["new_macro"] = "Nouvelle Macro";
                translations["refresh"] = "Actualiser";
                translations["save"] = "Enregistrer";
                translations["save_confirm"] = "Voulez-vous sauvegarder les changements faits sur la macro\n{0} ?";
                translations["save_title"] = "Macro modifiée";
                translations["scratchpad"] = "Ardoise";
                translations["scratchpad_instructions"] = "Le nom des touches pressées apparait ci dessous.\r\nVous pouvez ensuite les utiliser dans vos macros.";
                translations["scratchpad_title"] = "Ardoise des entrées clavier";
                translations["settings"] = "Réglages";
                translations["unsupported"] = "Non supporté";
                translations["welcome_text_1"] = "Bienvenue dans " + Program.Name + " !";
                translations["welcome_text_2"] = "Le programme se place dans la zone de notification de la barre des tâches : pour le configurer faites un clic droit sur l'icône.";
                translations["welcome_text_3"] = "La touche d'activation par défaut est la touche MENU, un petit menu est généralement dessiné dessus.";
                translations["welcome_text_4"] = "Souhaitez-vous lire le mode d'emploi ?";
                translations["welcome_title"] = "Bienvenue dans " + Program.Name + " v" + Program.Version;
                translations["window_info_result_text"] = "Nom : {0}\nProcessus : {1}";
                translations["window_info_result_title"] = "Infos sur le programme";
                translations["windows"] = "Fenêtres";

            }
            else
            {
                translations["about"] = "About";
                translations["about_description"] = "This app allows easy macro creation for games and applications.";
                translations["about_readme_file"] = "Readme-En.txt";
                translations["about_readme_file_not_found_text"] = "Help file {0} is missing!";
                translations["about_readme_file_not_found_title"] = "Missing file";
                translations["about_text"] = Program.Name + " v" + Program.Version + " - by ORelio";
                translations["about_text_year"] = Program.Name + " v" + Program.Version + " - © " + Program.Year + " ORelio";
                translations["about_title"] = Program.Name + " v" + Program.Version;
                translations["about_title_dialog"] = "About " + Program.Name;
                translations["about_website"] = "Website (FR) : http://microzoom.fr/";
                translations["activate"] = "Activate";
                translations["activate_key_changed"] = "Macro Activate key has been successfully set.";
                translations["activate_key_instructions"] = "Click OK then press any key.";
                translations["activate_key_instructions_title"] = "Choose a key";
                translations["activate_key_prompt"] = "The Activate key + Macro key combination is used to trigger standard macros. Change Activate key ?";
                translations["activate_key_title"] = "Activate key";
                translations["already_running"] = Program.Name + " is already running.\nClick on the notification area icon to access it.";
                translations["clear"] = "Clear";
                translations["close"] = "Close";
                translations["close_this_menu"] = "Close this menu";
                translations["copy"] = "Copy";
                translations["delete"] = "Delete";
                translations["delete_confirm"] = "Are you sure to permanently delete the macro\n{0}?\nIt will be lost forever (a long time!)";
                translations["delete_title"] = "Macro deletion";
                translations["disable"] = "Disable";
                translations["enable"] = "Enable";
                translations["exit"] = "Exit";
                translations["explorer"] = "Explorer";
                translations["help_file"] = "Help file";
                translations["info_instructions"] = "Select a window of your choice and press the Activate key to get information about it.";
                translations["info_title"] = "Window information";
                translations["macro"] = "Macro";
                translations["macro_definitions"] = "Macro definitions";
                translations["macro_editor"] = "Macro Editor";
                translations["minimize"] = "Minimize";
                translations["new"] = "New";
                translations["new_macro"] = "New Macro";
                translations["refresh"] = "Refresh";
                translations["save"] = "Save";
                translations["save_confirm"] = "Save changes to {0} ?";
                translations["save_title"] = "Macro changed";
                translations["scratchpad"] = "Scratchpad";
                translations["scratchpad_instructions"] = "The name of pressed keys appears below.\r\nYou can use them in your macros.";
                translations["scratchpad_title"] = "Scratchpad";
                translations["settings"] = "Settings";
                translations["unsupported"] = "Unsupported";
                translations["welcome_text_1"] = "Welcome to " + Program.Name + "!";
                translations["welcome_text_2"] = "This app is launches in the notification area of the taskbar: to configure it, right click on the icon.";
                translations["welcome_text_3"] = "Default Activate key is MENU, a small menu is usually drawn on it.";
                translations["welcome_text_4"] = "Would you like to display the user manual?";
                translations["welcome_title"] = "Welcome to " + Program.Name + " v" + Program.Version;
                translations["window_info_result_text"] = "Name : {0}\nProcess : {1}";
                translations["window_info_result_title"] = "Program info";
                translations["windows"] = "Window Info";

            }
        }
    }
}
