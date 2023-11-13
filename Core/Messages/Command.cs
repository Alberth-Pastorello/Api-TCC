using FluentValidation.Results;
using MediatR;

namespace Core.Messages
{
  public abstract class Command<T> : Message, IRequest<T>
  {
    protected DateTime Timestamp { get; private set; }

    protected ValidationResult ValidationResult { get; set; }

    protected Command()
    {
      ValidationResult = new ValidationResult();
      Timestamp = DateTime.Now;
    }

    public virtual bool EhValido()
    {
      throw new NotImplementedException();
    }
  }
}
