using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOD
{
    namespace Facade
    {

        public class DvdPlayer
        {
            public void On() { Console.WriteLine("DvdPlayer is on."); }
            public void Play(string moviename) { Console.WriteLine("Playing "+moviename); }
            public void Off() { Console.WriteLine("DvdPlayer is off."); }
        }

        public class MovieProjector
        {
            public void On() { Console.WriteLine("MovieProjector is on"); }
            public void Off() { Console.WriteLine("MovieProjector is off"); }
            public void ScreenMode(int width, int height) { Console.WriteLine("Screen size is "+width+"x"+height); }
        
        }

        public class CeilingLight
        {
            public void Dim(int percentage) { Console.WriteLine("CeilingLight dim  "+percentage+"%"); }
            public void Bright() { Console.WriteLine("CeilingLight bright "); }
        }

        public class MovieScreen
        {
            public void Up() { Console.WriteLine("Movie screen is scrolling up."); }
            public void Down() { Console.WriteLine("Movie screen is scrolling down."); }
        }

        public class PopcornMaker
        {
            public void On() { Console.WriteLine("PopcornMaker is on, being making popcorn"); }
            public void Off() { Console.WriteLine("PopcornMaker is off"); }
            public void Pop() { Console.WriteLine("Popcorn is ready."); }
        }


        //facade class
        public class HomeTheaterFacade
        {
            private DvdPlayer _dvdPlayer;
            private MovieProjector _movieProjector;
            private MovieScreen _movieScreen;
            private CeilingLight _ceilingLight;
            private PopcornMaker _popcornMaker;
            public HomeTheaterFacade(DvdPlayer dvd_player, 
                MovieProjector movie_projector, 
                MovieScreen movie_screen,
                CeilingLight ceiling_light = null,
                PopcornMaker popcorn_maker = null
                )
            {
                _dvdPlayer = dvd_player;
                _movieProjector = movie_projector;
                _movieScreen = movie_screen;
                _ceilingLight = ceiling_light;
                _popcornMaker = popcorn_maker;
            }


            public void WatchMovie(string movie_name)
            {
                if (_popcornMaker != null)
                {
                    _popcornMaker.On();
                    _popcornMaker.Pop();
                }

                _movieScreen.Down();
                _movieProjector.On();
                _movieProjector.ScreenMode(42, 32);

                _ceilingLight.Dim(10);

                _dvdPlayer.On();
                _dvdPlayer.Play(movie_name); 
            }

            public void EndMovie()
            {
                _dvdPlayer.Off();
                _ceilingLight.Bright();
                _movieProjector.Off();
                _movieScreen.Up();
                if (_popcornMaker != null) _popcornMaker.Off();
            }



        }

        
    }
}
