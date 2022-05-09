﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GroupCoursework.Base;

namespace GroupCoursework.Models;

public class CastMember : IEntityBase
{
    public int ActorId { get; set; }
    public Actor Actor { get; set; }

    public int DvdId { get; set; }
    public DvdTitle DvdTitle { get; set; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
}