namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    /// <summary>
    /// TXS (Transfer X to Stack Pointer) is one of the Register transfer operations in 6502 instruction-set. The TXS
    /// operation transfers the content of Index Register X to the stack pointer. Please keep in mind that the stack
    /// pointer is different from stack structure in 6502 microprocessors. There is only one opcode which is "BA" for
    /// the TXS instruction.
    /// </summary>
    /// <remarks>
    /// Flags:
    /// N Z C I D V
    /// - -	- -	- -
    /// </remarks>
    internal class TransferIndexXToStackRegister : Instruction
    {
        internal TransferIndexXToStackRegister(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Implied, "TXS", 0x9A, 1, 2)
        {
        }

        internal override void Execute()
        {
            this.Machine.PushValueOnStack(this.Machine.RegisterX);
        }
    }
}
