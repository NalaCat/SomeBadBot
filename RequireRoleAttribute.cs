using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace DbotCore
{
    public class RequireRoleAttribute : PreconditionAttribute
    {
        private readonly ulong _requiredRoleId;

        public RequireRoleAttribute(ulong requiredRoleId)
        {
            _requiredRoleId = requiredRoleId;
        }
        public override Task<PreconditionResult> CheckPermissions(ICommandContext context, CommandInfo command, IServiceProvider services)
            => Task.FromResult(context.User is IGuildUser user && user.RoleIds.Any(x => x == _requiredRoleId) ? PreconditionResult.FromSuccess() : PreconditionResult.FromError("You don't have permission to do this"));
    }
}

