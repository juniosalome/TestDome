/*
    A playlist is considered a repeating playlist if any of the songs contain a reference to a previous song in the playlist.
    Otherwise, the playlist will end with the last song which points to null.

    Implement a function IsRepeatingPlaylist that, efficiently with respect to time used, 
        returns true if a playlist is repeating or false if it is not.

    For example, the following code prints "True" as both songs point to each other.
 */

using System;

public class Song
{
    private readonly string name; 
    public Song NextSong { get; set; }

    public Song(string name)
    {
        this.name = name;
    }

    public bool IsRepeatingPlaylist()
    {
        var slow = NextSong; 

        
        var fast = slow?.NextSong; 

        while (fast != null)
        {
            if (slow == this || slow == fast) 
                return true;

            
            slow = slow.NextSong; 
            fast = fast.NextSong; 

            if (fast != null)
                fast = fast.NextSong; 
        }

        return false;
    }

    public static void Main(string[] args)
    {
        var first = new Song("Hello");
        var second = new Song("Eye of the tiger");

        first.NextSong = second;
        second.NextSong = first;

        Console.WriteLine(first.IsRepeatingPlaylist());
    }
}