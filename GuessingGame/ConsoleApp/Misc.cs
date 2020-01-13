﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuessingGame.UI
{
    class Misc
    {
        public static readonly string help =  "Usage: (h)elp, (v)ersion, (s)ingle, (m)ulti\n"+
                                              "(a)bout, (l)icense, (q)uit, (e)xit, (c)lear";
        public static readonly string version = "0.3.0 - PreRelease 1";
        public static readonly string license = "All rights reserved. (C) 2020.\nMIT License";
        public static readonly string about = "             ^ Guessing Game ^             \n"+
                                              "       Developed by Stiles-X(github)       \n"+
                                              " A core API to get up to speed with making \n"+
                                              "        above-average GuessingGames.       \n\n"+
                                              "Features:                                  \n"+
                                              "  -Fully error handled                     \n"+
                                              "  -Just enough functions, for customization\n"+
                                              "  -Amazing sample Console UI implementation\n"+
                                              "  -Have docs/ manpage. RTFM or --help      \n"+
                                              "  -Made by passionate developer <3         \n\n"+
                                              "Special thanks :                           \n" +
                                              "  To my family for the support. PewDiePie  \n" +
                                              "for the entertainment. To HTMLDog, for the \n" +
                                              "first wander into code and Mosh, for first \n" +
                                              "programming in python. To FCC, TimCorey,   \n" +
                                              "Mark P., and more, and Reddit,StackOverflow\n" +
                                              "and the internet. Thank you all <3         \n"
                                              ;
        public static readonly string not_found = $"Command not found.\n{help}";
        public static readonly string s = "Entering single-player game";
        public static readonly string m = "Entering multi-player game";
        public static readonly string AsciiLogoV = GetAsciiLogo("v" + Misc.version);
        public static void ClearAsciiLogoV()
        {
            Console.Clear();
            Console.WriteLine(AsciiLogoV);
            Console.WriteLine("-------------------------------------------");
        }
        public static string GetAsciiLogo(string text = "")
        {
            return @"   _____                     _             
  / ____|                   (_)            
 | |  __ _   _  ___  ___ ___ _ _ __   __ _ 
 | | |_ | | | |/ _ \/ __/ __| | '_ \ / _` |
 | |__| | |_| |  __/\__ \__ \ | | | | (_| |
  \_____|\__,_|\___||___/___/_|_| |_|\__, |
  / ____| github.com/Stiles-X         __/ |
 | |  __  __ _ _ __ ___   ___        |___/ 
 | | |_ |/ _` | '_ ` _ \ / _ \             
 | |__| | (_| | | | | | |  __/   " + $"v0.3.0" + @"
 \_____ |\__,_|_| |_| |_|\___| "+"PreRelease 1  ";
        }
        public static bool Exist(string[] pattern, string matcher, MainMenuCommand value, out MainMenuCommand valueOut)
        {
            valueOut = value;
            if (Exist(pattern, matcher))
                return true;
            return false;
        }
        public static bool Exist(string[] pattern, string matcher, string value, out string valueOut)
        {
            valueOut = value;
            if (Exist(pattern, matcher))
                return true;
            return false;
        }
        public static bool Exist(string[] pattern, string matcher)
        {
            if (pattern.Any(x => x == matcher))
                return true;
            return false;
        }
        public static bool Exist(MainMenuCommand[] pattern, MainMenuCommand matcher)
        {
            if (pattern.Any(x => x == matcher))
                return true;
            return false;
        }
        public static string input(string question, bool writeQuestion = true)
        {
            if (writeQuestion)
                Console.Write(question);
            return Console.ReadLine();
        }
        public static int intput(string question)
        {
            string strAnswer = input(question).ToLower();
            var s = strAnswer;
            if (Exist(new[] { "c", "cls", "clear" }, s))
                ClearAsciiLogoV();
            if (Exist(new[] { "q", "quit", "e", "exit" }, s))
                throw new QuitException();
            bool CanParse = (int.TryParse(strAnswer, out int intAnswer));
            if (!CanParse)
            {
                Console.WriteLine("Please enter a valid input");
                intAnswer = intput(question);
            }
            return intAnswer;
        }
        
        public class QuitException : Exception
        {
            public QuitException() { }
            public QuitException(string message) : base(message) { }
        }
    }
}