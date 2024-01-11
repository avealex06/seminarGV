namespace TheStrangeCaseOfPRG
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //function to take care of the choices
            static int Choice(Options options)
            {

                while (true)
                {

                    try
                    {
                        //goes through the whole list and prints the correct next line into the console
                        int choice = Convert.ToInt32(Console.ReadLine());
                        for (int i = 1; i <= options.next.Count; i++)
                        {
                            if (choice == i)
                            {

                                Console.WriteLine(options.next.ElementAt(i-1).text);
                                



                                return choice;
                            }
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("invalid choice, try again");


                    }
                }
                return 0;


            }

            

            
            //ENTERING THE ROOM TEXT
            Options initialText = new Options("The air is thick with tension as you approach the crime scene. The once vibrant PRG classroom is now eerily quiet, the usual buzz of student activity replaced by an oppressive silence. The walls, once adorned with colorful posters and student projects, now bear the grim marks of a tragic event.\\n\\nA body lies sprawled on the floor, the victim's lifeless eyes staring blankly at the ceiling. The room is a mess, overturned chairs and scattered papers suggesting a struggle. But what happened here? Who could have committed such a heinous act?\\n\\nYou are Detective [Your Name], a seasoned investigator with a reputation for solving the most perplexing cases. You've been called in to investigate this murder, the only one that no one has been able to crack. The pressure is immense, but you're ready to take on the challenge. As you get closer, you notice a couple of possible clues as to what might have happened. \n" +
                " 1. Inspect the blood on the wall \n" +
                " 2. Investigate the body \n" +
                " 3. Inspect the murder weapon \n" +
                " 4. Look at the shattered glass near the wall \n" +
                " 5. Move on to the police station ");

            
            Options clueOne = new Options("As you approach the wall on the other side you notice that the blood is in a weird slash, it seems it was a spray from a wound made by an impact. It's small so likely not a huge wound.", initialText);
            initialText.AddNext(clueOne);
            Options clueTwo = new Options("The head has been caved in and there is blood all around, the murder weapon left just beside the body", initialText);
            initialText.AddNext(clueTwo);
            Options clueThree = new Options("A hammer, certainly an interesting choice for a murder weapon", initialText);
            initialText.AddNext(clueThree);
            Options clueFour = new Options("A shattered glass of water near the wall with the blood, you wonder what happened", initialText);
            initialText.AddNext(clueFour);
            Options clueMoveOn = new Options("As you get to the police station, you are greeted by your assistant who tells you that there are four suspects and no witnesses. All the suspects are in police custody. Which one do you want to interrogate first?\n" +
                "1.The Janitor\n" +
                "2. The Quiet Kid \n" +
                "3. The Server Guy \n" +
                "4. The Teacher \n" +
                "5. Choose the culprit", initialText);
            initialText.AddNext(clueMoveOn);



            //INTERROGATION ROOM

            //SUSPECT DESCRIPTIONS
            Options descOne = new Options("The school janitor, a weathered man with calloused hands and tired eyes, entered the interrogation room, his worn uniform suggesting years of dedicated service. As he settled into the chair, the subtle traces of concern etched across his face hinted at the weight of the unfolding investigation in which he unexpectedly found himself entangled. \n\n When asked about where he was at the time of the crime, the school janitor claimed he was busy cleaning the far end of the school premises. However, his alibi relies solely on his word, as there were no witnesses or security footage to corroborate his story. The lack of concrete evidence leaves room for skepticism about his whereabouts.", clueMoveOn);
            clueMoveOn.AddNext(descOne);
            Options descTwo = new Options("The quiet kid, with a demeanor that seemed to blend into the background, entered the interrogation room with a palpable air of nervousness. His downcast eyes and hesitant movements hinted at a reluctance to be at the center of attention, leaving an enigmatic aura that begged the question of what secrets might be hidden behind his reserved exterior. \n\n When asked about where he was at the time of the crime, the quiet kid insisted he was engrossed in a study group at the library. Despite his claim, some classmates vaguely recall his presence, and the sign-in records are inconclusive. The quiet kid's alibi rests on shaky details, creating doubt about the accuracy of his account.", clueMoveOn);
            clueMoveOn.AddNext(descTwo);
            Options descThree = new Options("The server guy, his disheveled appearance contrasting sharply with the usual composure, entered the interrogation room nursing a visible slash wound along his forearm. Despite the bandaged injury, there was a stoic determination in his gaze, suggesting a resilience forged in the face of unexpected challenges. As he took a seat, the room seemed to carry the weight of both the crime investigation and the personal ordeal etched into his wounded flesh.\n\n When asked about where he was at the time of the crime, the server guy asserted he was addressing a critical server issue leading to the visible slash wound on his forearm. However, the specific details of the server problem remain unclear, and there is no documentation or additional evidence to support his narrative. His alibi raises questions about the legitimacy of his actions.", clueMoveOn);
            clueMoveOn.AddNext(descThree);
            Options descFour = new Options("The teacher, wearing an expression of concern that transcended the professional facade, entered the interrogation room with a subtle air of authority. His thoughtful demeanor and carefully chosen words betrayed a meticulous nature, but the slight tremor in his hands hinted at the emotional toll of the unfolding investigation. As he settled into the chair, the combination of resolve and vulnerability painted a complex portrait of someone caught between duty and personal involvement in the unsettling circumstances. Notably, an observant eye might catch a glimpse of a small wound on his hand, hastily concealed under the edge of his sleeve, adding an intriguing layer to the unfolding narrative.\n\n When asked about where he was at the time of the crime, the teacher maintained he was engaged in a parent-teacher conference. Despite a few parents vaguely remembering the meeting, the school's scheduling system shows inconsistencies in his claimed timeline. The teacher's alibi seems shaky, with conflicting accounts and potential discrepancies that cast doubt on his innocence.", clueMoveOn);
            clueMoveOn.AddNext(descFour);

            Options choice = new Options("You decide it is time to reveal the perpetrator to the world and make sure he gets locked up for good. Who do you pick?\n" +
                "1.The Janitor \n" +
                "2.The Quiet Kid\n" +
                "3.The Server Guy\n" +
                "4.The Teacher", clueMoveOn);
            clueMoveOn.AddNext(choice);

            //ENDINGS
            Options endOne = new Options("Poor old man, you have just sentenced him to spend the rest of his life rotting away in a cell, even though he never did anything wrong. He is too old to even try to resist and just resigns himself to fate. What a sad end to his tale...", choice);
            choice.AddNext(endOne);
            Options endTwo = new Options("He was innocent. Yes, you just sentenced a kid to prison... Good job... little do you know that this decision will come back to haunt you once he gets out of there and sets out on his personal vendetta against you. ", choice);
            choice.AddNext(endTwo);
            Options endThree = new Options("Yes, he was the one!! You made the right choice either by accident or you took into consideration his slash wound and the stupid fairytale he told you about how he got it. Good job detective.", choice);
            choice.AddNext(endThree);
            Options endFour = new Options("Good job, you have just robbed the class of an amazing teacher... Who will teach them the subject now?? You might have just ruined the futures of all the kids in that class...", choice);
            choice.AddNext(endFour);


            Console.WriteLine(" _____ _   _ _____   ____ _____ ____      _    _   _  ____ _____ \n|_   _| | | | ____| / ___|_   _|  _ \\    / \\  | \\ | |/ ___| ____|\n  | | | |_| |  _|   \\___ \\ | | | |_) |  / _ \\ |  \\| | |  _|  _|  \n  | | |  _  | |___   ___) || | |  _ <  / ___ \\| |\\  | |_| | |___ \n  |_|_|_| |_|_____| |____/ |_|_|_| \\_\\/_/  _\\_\\_|_\\_|\\____|_____|\n / ___|  / \\  / ___|| ____|  / _ \\|  ___| |  _ \\|  _ \\ / ___|    \n| |     / _ \\ \\___ \\|  _|   | | | | |_    | |_) | |_) | |  _     \n| |___ / ___ \\ ___) | |___  | |_| |  _|   |  __/|  _ <| |_| |    \n \\____/_/   \\_\\____/|_____|  \\___/|_|     |_|   |_| \\_\\\\____| \n ________________________________________________________________ \n  ");
            Console.WriteLine(initialText.text);
            //Console.WriteLine(initialText.next.ElementAt(1).text);
            //ListOptions(initialText);
            while (Choice(initialText) != 5)
            {
                Choice(initialText);
            }
            while (Choice(clueMoveOn) !=5)
            {
                Choice(clueMoveOn);
            }

            Choice(choice);


            


            Console.ReadKey();
        }
    }
}
