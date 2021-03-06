// Copyright (c) 2012, Event Store LLP
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are
// met:
// 
// Redistributions of source code must retain the above copyright notice,
// this list of conditions and the following disclaimer.
// Redistributions in binary form must reproduce the above copyright
// notice, this list of conditions and the following disclaimer in the
// documentation and/or other materials provided with the distribution.
// Neither the name of the Event Store LLP nor the names of its
// contributors may be used to endorse or promote products derived from
// this software without specific prior written permission
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
// HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// 

using System;
using System.Collections.Generic;
using EventStore.Projections.Core.Messages;
using EventStore.Projections.Core.Services.Processing;
using NUnit.Framework;

namespace EventStore.Projections.Core.Tests.Services.core_projection.checkpoint_manager
{
    [TestFixture]
    public class when_a_core_projection_checkpoint_manager_has_been_created : TestFixtureWithCoreProjectionCheckpointManager
    {
        [Test, ExpectedException(typeof (InvalidOperationException))]
        public void stopping_throws_invalid_operation_exception()
        {
            _manager.Stopping();
        }

        [Test, ExpectedException(typeof (InvalidOperationException))]
        public void stopped_throws_invalid_operation_exception()
        {
            _manager.Stopped();
        }

        [Test, ExpectedException(typeof(InvalidOperationException))]
        public void event_processed_throws_invalid_operation_exception()
        {
//            _manager.StateUpdated("", @"{""state"":""state""}");
            _manager.EventProcessed(CheckpointTag.FromStreamPosition("stream", 10), 77.7f);
        }

        [Test, ExpectedException(typeof(InvalidOperationException))]
        public void checkpoint_suggested_throws_invalid_operation_exception()
        {
            _manager.CheckpointSuggested(CheckpointTag.FromStreamPosition("stream", 10), 77.7f);
        }

        [Test, ExpectedException(typeof(InvalidOperationException))]
        public void ready_for_checkpoint_throws_invalid_operation_exception()
        {
            _manager.Handle(new CoreProjectionProcessingMessage.ReadyForCheckpoint(null));
        }

        [Test, ExpectedException(typeof(InvalidOperationException))]
        public void starts_throws_invalid_operation_exception()
        {
            _manager.Start(CheckpointTag.FromStreamPosition("stream", 10));
        }

        [Test]
        public void can_begin_load_state()
        {
            _manager.BeginLoadState();
        }

    }
}
