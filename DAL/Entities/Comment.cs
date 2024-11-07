﻿using System;
using System.Collections.Generic;

namespace TaskTrack.DAL.Entities;

public partial class Comment
{
    public int CommentId { get; set; }

    public int UserId { get; set; }

    public int TaskId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public virtual Task Task { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
