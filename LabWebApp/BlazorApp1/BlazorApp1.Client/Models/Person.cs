using System.Collections.Immutable;

namespace BlazorApp1.Client.Models
{
    public class One(int Id, int[] arr);

    public record Person(int Id, One one, string Name)
    {
        public void One()
        {
            var l = 1;
            l;
            var s = new One(1, []);
        }

        
    }


}
