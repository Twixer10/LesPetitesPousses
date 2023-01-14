using System.ComponentModel.DataAnnotations.Schema;

namespace LPP.Entities;

public abstract class EntityBase
{
    public Guid Id { get; set; } = Guid.NewGuid();


    [DatabaseGenerated(DatabaseGeneratedOption
        .Identity)] /// se met à jour uniquement a l'ajout de la donnée dans la bdd
    public DateTime CreatedAt { get; set; } = default(DateTime);

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)] /// se met à jour a la modification de la donnée
    public DateTime UpdatedAt { get; set; } = default!;
}