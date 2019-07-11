using System;
using System.Web;
using System.Collections.Generic;
using System.Web.UI;


namespace bingo
{

    public partial class Home : System.Web.UI.Page
    {
        #region Variables
        private const int MAX_RECURSIVE_CALLS = 100;
        static int ctr = 0;
        List<Song> lPlayList = new List<Song>();
        List<Song> lTmpPlayList = new List<Song>();
        List<Song> lFilmList = new List<Song>();
        Song answerSong = new Song();
        int nCurrentIndex = 0;
        #endregion Variable

        private void Page_Load()
        {
            #region Fill values
            lPlayList.Add(new Song(1, "<iframe src=\"https://open.spotify.com/embed/track/4JLcAU2xY90qTkTSNM1lUa\" width=\"300\" height=\"380\" frameborder=\"0\" allowtransparency=\"true\" allow=\"encrypted-media\"></iframe>", "Kill Bill 1")); // My Baby shot me down
            lPlayList.Add(new Song(2, "<iframe src=\"https://open.spotify.com/embed/track/6ZIkH0yQk0E5hfOVL7CyoQ\" width=\"300\" height=\"380\" frameborder=\"0\" allowtransparency=\"true\" allow=\"encrypted-media\"></iframe>", "Boulevard de la mort")); // Laissez tomber les filles
            lPlayList.Add(new Song(3, "<iframe src=\"https://open.spotify.com/embed/track/0xNWHoHZQEYo8iFH4QdwbK\" width=\"300\" height=\"380\" frameborder=\"0\" allowtransparency=\"true\" allow=\"encrypted-media\"></iframe>", "Natural Born Killers")); // Waiting for a miracle
            lPlayList.Add(new Song(4, "<iframe src=\"https://open.spotify.com/embed/track/1BmVQ5RGqqtF5cnsv6cQYu\" width=\"300\" height=\"380\" frameborder=\"0\" allowtransparency=\"true\" allow=\"encrypted-media\"></iframe>", "Pulp Fiction")); // Girl you'll be a woman
            lPlayList.Add(new Song(5, "<iframe src=\"https://open.spotify.com/embed/track/5CtKsA5lA75wWaqxrC1r02\" width=\"300\" height=\"380\" frameborder=\"0\" allowtransparency=\"true\" allow=\"encrypted-media\"></iframe>", "Jackie Brown")); // Street Life
            lPlayList.Add(new Song(6, "<iframe src=\"https://open.spotify.com/embed/track/3uG4ygD1bIP3YspJm9N4KO\" width=\"300\" height=\"380\" frameborder=\"0\" allowtransparency=\"true\" allow=\"encrypted-media\"></iframe>", "Pulp Fiction")); // Flowers on the wall
            lPlayList.Add(new Song(7, "<iframe src=\"https://open.spotify.com/embed/track/20jhZ58fJ7xTkTudhxrWQg\" width=\"300\" height=\"380\" frameborder=\"0\" allowtransparency=\"true\" allow=\"encrypted-media\"></iframe>", "Resevoir Dogs")); // Little green bag
            lPlayList.Add(new Song(8, "<iframe src=\"https://open.spotify.com/embed/track/3XpJO7x4y6MLdwo5QU2sA8\" width=\"300\" height=\"380\" frameborder=\"0\" allowtransparency=\"true\" allow=\"encrypted-media\"></iframe>", "Kill Bill 2")); // Goodnight moon 
            #endregion Fill values

            if (!IsPostBack)
            {
                if (ViewState["nScore"] == null)
                {
                    ViewState["nScore"] = 0;
                }
                Score.Text = " " + ViewState["nScore"].ToString();


                if (ViewState["nCount"] == null)
                {
                    ViewState["nCount"] = 0;
                }

                if (ViewState["nPlayedIndex"] == null)
                {
                    ViewState["nPlayedIndex"] = -1;
                }

                try
                {
                        Play();
                }
                catch (Exception exp)
                {
                    Response.Redirect("Error.aspx"); 
                }

            }
        }


        /* 
         * Generates a random number 
         * Stores it into a viewstate variable
         * Displays a song from the playlist at the index equals to the generated random number     
         * Three cases possible:
         * 1. Random number is Ok (between 0 and 7 included)
         * 2. Random number is out of range -> calls itself by recursion. Recursion calls are limited to 100 consecutive calls.
         * 3. Random number is out of rand and the max limit of recursive call is exceeded -> A default case with index 0.
         */
        public void Play()
        {
            
            Random rnd = new Random();
            nCurrentIndex = rnd.Next(lPlayList.Count);
            ViewState["nCurrentIndex"] = nCurrentIndex;

            ctr++;

            if (nCurrentIndex >= 0 && nCurrentIndex < 8 && nCurrentIndex != (int)ViewState["nPlayedIndex"])
            {
                DisplaySong(nCurrentIndex, lPlayList);
                SetTitlesRadioGroup(lPlayList[nCurrentIndex], lPlayList);
                ViewState["nPlayedIndex"] = nCurrentIndex;
            }
            else if (ctr < MAX_RECURSIVE_CALLS)
            {
                Play();
            }
            else {
                DisplaySong(0, lPlayList);
                SetTitlesRadioGroup(lPlayList[0], lPlayList);
                ViewState["nPlayedIndex"] = 0;
            }
            ctr--;
        }


        /* 
         * Param pIndex of a Song in playlist
         * Param pPlaylist
         * Sets embedded Spotify url to web page video container source
         */
        public void DisplaySong(int pIndex, List<Song> pPlayList)
        {
            if (pPlayList.Count > 0 && pIndex >= 0 && pIndex < pPlayList.Count)
            {
                videoContainer.Text = pPlayList[pIndex].song_url;
            } else
            {
                throw new IndexOutOfRangeException();
            }
           
        }


        /* 
         * Param object Song - the song to play
         * Param playlist
         * Shuffles given in parameter playlist       
         * Adds Song from parameter film title to a temporary filmlist - this is the correct answer
         * Takes 2 first songs from playlist and adds them to a new temporary filmlist
         * Shuffles film titles list - this is the answers list 
         * Maps movies titles from that list to Radio boxes  
         */
        public void SetTitlesRadioGroup(Song oSong, List<Song> pPlayList)
        {
            lTmpPlayList = pPlayList;
            lTmpPlayList = ShuffleList(lTmpPlayList);
            answerSong = oSong;

            lFilmList.Add(answerSong);

            for (int i = 0; i < pPlayList.Count && lFilmList.Count < 3; i++)
            {
                if (ContainsSong(pPlayList[i], lFilmList) == false)
                {
                    lFilmList.Add(lTmpPlayList[i]);
                }
            }

            lFilmList = ShuffleList(lFilmList);

            Film1Radio.Text = lFilmList[0].film;
            Film2Radio.Text = lFilmList[1].film;
            Film3Radio.Text = lFilmList[2].film;
        }


        /* 
         * Param playlist
         * Swaps the elements of the playlist
         * Returns a shuffled playlist of songs
         */
        public List<Song> ShuffleList(List<Song> pPlayList)
        {
            List<Song> tmpPlayList = pPlayList;

            Random rn = new Random();

            if (tmpPlayList.Count > 1)
            {
                for (int i = tmpPlayList.Count - 1; i >= 0; i--)
                {
                    Song tmpSong = tmpPlayList[i];
                    int randomIndex = rn.Next(i + 1);

                    //Swap elements
                    tmpPlayList[i] = tmpPlayList[randomIndex];
                    tmpPlayList[randomIndex] = tmpSong;
                }
            }

            return tmpPlayList;
        }


        /* 
         * Param song object
         * Param playlist of songs
         * Check if playlist in parameter contains the song in parameter
         * Returns true or false         
         */
        public bool ContainsSong(Song oSong, List<Song> pPlayList)
        {
            bool bContains = false;
            foreach (Song s in pPlayList)
            {
                if (oSong.film == s.film)
                {
                    return true;
                }
            }

            return bContains;
        }

        /* 
         * Checks user answer
         * Verifies if checked radiobox text corresponds to the movie title of playing song
         * Returns true or false   
         */
        public bool CheckAnswer()
        {
            int nSavedIndex = (int)ViewState["nCurrentIndex"];

            if (Film1Radio.Checked && Film1Radio.Text == lPlayList[nSavedIndex].film)
            {
                return true;
            }
            else if (Film2Radio.Checked && Film2Radio.Text == lPlayList[nSavedIndex].film)
            {
                return true;
            }
            else if (Film3Radio.Checked && Film3Radio.Text == lPlayList[nSavedIndex].film)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* 
         * Clear checked radioboxes for a new question
         */
        public void ResetRadioGroup()
        {
            Film1Radio.Checked = false;
            Film2Radio.Checked = false;
            Film3Radio.Checked = false;
        }


        /* 
         * Counts the number of played steps
         * If the count reaches the limit, swaps visibility of Playing and GameOver panels 
         * Return bool true if the count is less  10
         * Returns bool false if the count is more or equals to 10
         */
        public bool CountTurns()
        {
            int nCount = (int)ViewState["nCount"] + 1;
            ViewState["nCount"] = nCount;

            if (nCount >= 10)
            {
                
                return false;
            }

            return true;
        }

        /* 
       * Clear ViewStateVariables
       */
        public void ClearViewStateVar()
        {
            ViewState["nScore"] = null;
            ViewState["nCount"] = null;
            ViewState["nCurrentIndex"] = null;
            ViewState["nPreviousIndex"] = null;
        }
        /* 
         * Checks and displays the score
         * Checks the count
         * If the count is less them limit, displays a new song and new set of answers    
         */
        public void BtnSubmitClicked(object sender, EventArgs args)
        {
            bool bCorrectAnswer = CheckAnswer();
            bool bContinue = true;
            int nScore = 0;

            if (bCorrectAnswer)
            {
                nScore = (int)ViewState["nScore"] + 10;
            } else {
                nScore = (int)ViewState["nScore"];
            }
            Score.Text = nScore.ToString();
            ViewState["nScore"] = nScore;
           

            bContinue = CountTurns();
            if (bContinue)
            {
                Play();
                ResetRadioGroup();
            } else
            {
                ClearViewStateVar();
                Response.Redirect("gameover.aspx?score=" + nScore);
            }
        }

    }
}

