using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bingo
{
    public class Song
    {
        #region variables
        int nId;
        string sUrl;
        string sFilm;

        #endregion variables

        /* 
         * gets property song id    
         * sets property song id  
         */
        public  int song_id
        {
            get
            {
                return nId;
            }

            set
            {
                if (value > 0 && value <= 10)
                {
                    nId = value;
                }
            }
        }


        /* 
         * gets property song url     
         * sets property ssong url 
         */
        public string song_url
        {
            get
            {
                return sUrl;
            }

            set
            {
                sUrl = value;
            }
        }

        /* 
         * gets proprety song film title     
         * sets proprety song film title   
         */
        public string film
        {
            get
            {
                return sFilm;
            }

            set
            {
                sFilm = value;
            }
        }


        /* 
         * Empty constructor    
         */
        public Song()
        {

        }

        /* 
         * Constructor with three parameters       
         * int Id
         * string Url
         * string soundtrack's film title
         */
        public Song(int pId, string pUrl, string pFilm)
        {
            nId = pId;
            sUrl = pUrl;
            sFilm = pFilm;
        }

    }
}