**Project Documentation:**

**This project consists of primarily 3 parts**:

1. **Leaderboard Manager** - a singleton that is in-charge of all the generated players that are stored inside of the list and is the one that in charge of sorting the players via its two sorted sets.

2\. **Leaderboard UI**  - the visual representation of the leaderboard that uses the sorted sets of leaderboard manager to show the top 20 players in both the coin and level department, it also contains a tab that shows the player separate from the leaderboard as to see where the player is in comparison to the top 20. .

3\. **Player Generator** - creates and populates a list of 100 players with 99 of them being named player 0-98 and one unique player possessing my name and having a fixed value for their level and coins instead of a random value like the rest.

**How to Run:**

1. Download the Unity version 6000.2.2f1.
2. Open the Scenes folder and go to the Final Scene.
3. Run the Scene via the editor and press the leaderboard button.

**Workflow:**

For the workflow of the project I started by reading the specs needed for the program then writing down how the process should go. Once i decided how the pipeline of player generation to sorting players to displaying sorted players would go i went into programming the leaderboard manager as it was what held everything together, after finishing the manager i programmed the player generator in-order to test if my leaderboard manager was working and sorting the players properly after fixing up the bugs and seeing that it sorted properly i moved on to the GUI and integrating it to my system until it was complete.
**Use of AI:**
For this project the use of AI(Claude app) was heavily done during the UI Portion of the assignment as I had made use of Unity's UI toolkit which is a tool i haven't made use of in a long time but is a good tool for developing mobile games due to it's scalability. Early on AI was used more of as a guide and to correct my code with prompts such as "How would i sort 100 people in order of coins and level given my struct of player" and "What if I want to scale it over 100 people" with auxiliary questions on how it works when running. Other than that I usually used The AI like a search engine for things I forgot how to do or to check if my train of thought was correct. I leaned a lot more heavily into using it when it came to the creation of GUI as UI Toolkit is very difficult to work with as you usually have to make use of USS to modify the placements of variables and objects. Since I had worked on a similar situation for the UI before primarily using a similar layout as the one used in leaderboard for an inventory system I fed claude the code I used for the inventory and asked it to give me the leaderboard ui from it. for connecting the UI with the manager I fed claude my old code and told it to use that as reference for what I wanted to happen.
**Time Taken:**
For this project the time it took to finish would be around 2 - 3 hours

**Planning** - 20 mins : consists of thinking up a data type for player and making the workflow for the project.

**Programming the Data and Manager** - 50 mins: was made faster with the help of AI aiding with concepts I forgot about.

**GUI creation** - 40 mins : Started with making the GUI from scratch but was made faster with feeding old code to claude to make the uxml and uss.

**GUI integration** - 20 mins: was mostly fixing up code that claude gave and finding the old code i had made in my old project.

**Polishing** - 20 mins: was mostly fixing up the font sizes and UI sizes for user readability.

The rest of the time left I leave for the breaks i took in between working on the project.
**Challenges:**
Most of the challenges that I encountered in this text was aided by the use of AI and became negligible in the long run but the UI was where I would have had trouble with as even if i had done the UI style before I had done it 2 years ago off of youtube tutorial i have no memory or link to. Without AI I would have most likely taken most of my time with the UI portion of the program primarily through reverse engineering my old code.

