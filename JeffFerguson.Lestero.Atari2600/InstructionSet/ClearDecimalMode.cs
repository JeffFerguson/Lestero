namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    /// <summary>
    /// Implementation of the CLD instruction as documented at http://6502.org/tutorials/6502opcodes.html#CLD.
    /// </summary>
    /// <remarks>
    /// Flags:
    /// N Z C I D V
    /// - -	- -	0 -
    /// </remarks>
    internal class ClearDecimalMode : Instruction
    {
        internal ClearDecimalMode(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Implied, "CLD", 0xD8, 1, 2)
        {
        }

        internal override void Execute()
        {
            this.Machine.DecimalFlag = false;
        }
    }
}
