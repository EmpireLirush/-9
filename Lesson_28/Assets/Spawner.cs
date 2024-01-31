using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();
    [SerializeField] private List<int> _healths = new List<int>();
    [SerializeField] private List<int> _healthsFiltered;
    [SerializeField] private Color _color;

    public void Awake()
    {
        Debug.Log(_healths.Contains(4));
    }
}

public class Person
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public List<string> Languages { get; private set; }
    public Person(string name, int age, List<string> languages)
    {
        Name = name;
        Age = age;
        Languages = languages;
    }
}
