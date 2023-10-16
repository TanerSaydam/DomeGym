using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeGym.Domain;
public static class TrainerErrors
{
    public static readonly Error CannotHaveTwoOrMoreOverlappingSessions = Error.Validation(
         "Trainer.CannotHaveTwoOrMoreOverlappingSessions",
          "A trainer cannot have two or more overlapping sessions");
}
