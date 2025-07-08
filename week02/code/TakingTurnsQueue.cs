public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add new people to the queue with a name and number of turns
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and return them. The person should
    /// go to the back of the queue again unless the turns variable shows that they 
    /// have no more turns left.  Note that a turns value of 0 or less means the 
    /// person has an infinite number of turns.  An error exception is thrown 
    /// if the queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        var person = _people.Dequeue();

        // Retorna a pessoa primeiro, depois decide se ela volta para a fila
        var result = new Person(person.Name, person.Turns); // cópia para preservar valor original

        if (person.Turns > 1)
        {
            person.Turns -= 1;
            _people.Enqueue(person);
        }
        else if (person.Turns <= 0)
        {
            // Infinite turns, re-enfileira sem mudar nada
            _people.Enqueue(person);
        }
        // Se turns == 1, não re-enfileira (foi a última vez)

        return result;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
