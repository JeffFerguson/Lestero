using System;

namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    /// <summary>
    /// See https://sites.google.com/site/6502asembly/6502-instruction-set/inx
    /// </summary>
    /// <remarks>
    /// N Z C I D V
    /// + +	- -	- -
    /// </remarks>
    internal class IncrementIndexXByOne : Instruction
    {
        internal IncrementIndexXByOne(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Implied, "INX", 0xE8, 1, 2)
        {
        }

        internal override void Execute()
        {
            ManageNegativeFlag(this.Machine.RegisterX, (byte)(this.Machine.RegisterX + 1));
            this.Machine.RegisterX++;
            ManageZeroFlag(this.Machine.RegisterX);
        }
    }
}
