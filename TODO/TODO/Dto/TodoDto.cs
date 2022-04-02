using System.Runtime.Serialization;

namespace TODO.Dto;

[DataContract]
public class TodoDto
{
    [DataMember( Name = "id_todo" )]
    public int Id { get; set; }
    
    public string Title { get; set; }
    public bool IsDone { get; set; }
}