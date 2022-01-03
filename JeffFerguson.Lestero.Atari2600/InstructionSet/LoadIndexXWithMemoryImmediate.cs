using System;

namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    /// <summary>
    /// LDX
    /// </summary>
    /// <remarks>
    /// Flags:
    /// N Z C I D V
    /// + +	- -	- -
    /// </remarks>
    internal class LoadIndexXWithMemoryImmediate : InstructionWithByteOperand
    {
        internal LoadIndexXWithMemoryImmediate(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Immediate, "LDX", 0xA2, 2, 2)
        {
        }

        internal override void Execute()
        {
            ManageNegativeFlag(this.Machine.RegisterX, this.Operand);
            this.Machine.RegisterX = this.Operand;
            ManageZeroFlag(this.Operand);
        }
    }
}
