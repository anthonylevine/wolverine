using System;
using System.Collections.Generic;
using JasperFx.CodeGeneration.Frames;
using Lamar;

namespace Wolverine.Configuration;

#region sample_IChain

/// <summary>
///     Models the middleware arrangement for either an HTTP route execution
///     or the execution of a message
/// </summary>
public interface IChain
{
    /// <summary>
    ///     Frames that would be initially placed in front of
    ///     the primary action(s)
    /// </summary>
    List<Frame> Middleware { get; }

    /// <summary>
    ///     Frames that would be initially placed behind the primary
    ///     action(s)
    /// </summary>
    List<Frame> Postprocessors { get; }

    /// <summary>
    ///     A description of this frame
    /// </summary>
    string Description { get; }

    /// <summary>
    ///     Used internally by Wolverine for "outbox" mechanics
    /// </summary>
    /// <returns></returns>
    bool ShouldFlushOutgoingMessages();
    
    bool RequiresOutbox();

    MethodCall[] HandlerCalls();

    /// <summary>
    ///     Find all of the service dependencies of the current chain
    /// </summary>
    /// <param name="chain"></param>
    /// <param name="container"></param>
    /// <returns></returns>
    IEnumerable<Type> ServiceDependencies(IContainer container);

    /// <summary>
    /// Does this chain have the designated attribute type anywhere in
    /// its handlers?
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    bool HasAttribute<T>() where T : Attribute;

    /// <summary>
    /// The input type for this chain
    /// </summary>
    /// <returns></returns>
    Type? InputType();
}

#endregion