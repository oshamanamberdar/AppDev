﻿using System.ComponentModel.DataAnnotations.Schema;
using GroupCoursework.Base;

namespace GroupCoursework.Models;

public class CastMember
{

    public int ActorId { get; set; }
    public Actor Actor { get; set; }
    
    public int DvdId { get; set; }
    public DvdTitle DvdTitle { get; set; }

  
}