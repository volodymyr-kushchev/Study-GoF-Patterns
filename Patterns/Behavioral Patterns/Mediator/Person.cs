using System;
using System.Collections.Generic;
using System.Linq;

namespace Behavioral_Patterns.Mediator
{
    public class Person
    {
        public string Name;
        public ChatRoom Room;
        private List<string> chatLog = new List<string>();

        public Person(string name)
        {
            this.Name = name;
        }

        public void Say(string message)
        {
            Room.Broadcast(Name, message);
        }


        public void PrivateMessage(Person receiver, string message)
        {
            Room.Message(Name, receiver.Name, message);
        }

        public void Receive(string sender, string message)
        {
            String s = $"{sender}: '{message}'";
            Console.WriteLine($"[{Name}'s chat session] {s}");
            chatLog.Add(s);
        }
    }

    public class ChatRoom
    {
        private List<Person> people = new List<Person>();

        public ChatRoom()
        {

        }

        public void Broadcast(string source, string message)
        {
            foreach(var person in people)
            {
                if (person.Name != source)
                    person.Receive(person.Name, message);
            }
        }

        public void Join(Person newcommer)
        {
            string joinMessage = $"{newcommer.Name} has joined to the chat";
            Broadcast("room", joinMessage);

            newcommer.Room = this;
            people.Add(newcommer);
        }

        public void Message(string sender, string receiver, string message)
        {
            people.FirstOrDefault(p => p.Name == receiver)?.Receive(sender, message);
        }

        public void Leave(Person person)
        {
            string leaveMessage = $"{person.Name} has left the chat";
            people.Remove(person);
            person.Room = null;
            Broadcast("room", leaveMessage);
        }
    }
}
