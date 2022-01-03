namespace JeffFerguson.Lestero.Atari2600.InstructionSet
{
    /// <summary>
    /// Implementation of the SEI instruction as documented at http://6502.org/tutorials/6502opcodes.html#SEI.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The Interrupt flag is used to prevent (SEI) or enable (CLI) maskable interrupts (aka IRQ's). It does not signal
    /// the presence or absence of an interrupt condition. The 6502 will set this flag automatically in response to an
    /// interrupt and restore it to its prior status on completion of the interrupt service routine. If you want your
    /// interrupt service routine to permit other maskable interrupts, you must clear the I flag in your code.
    /// </para>
    /// <para>
    /// Flags:
    /// N Z C I D V
    /// - -	- 1	- -
    /// </para>
    /// </remarks>
    internal class SetInterruptDisableStatus : Instruction
    {
        internal SetInterruptDisableStatus(VirtualMachine vm, ushort address) : base(vm, address, AddressingForm.Implied, "SEI", 0x78, 1, 2)
        {
        }

        /// <summary>
        /// Execute the SEI instruction.
        /// </summary>
        /// <remarks>
        /// The 6502 family microprocessors will NOT response if the Interrupt Flag is set to 1.  On the other hand, if the
        /// Interrupt Flag is set to 0, the 6502 family microprocessor resume a normal state that it will react to any interrupt
        /// request. Thus, the reaction to interrupt request can be DISABLED by SEI operation and ENABLED by CLI operation.
        /// SEI and CLI operations are designed specific for setting and clearing the Interrupt Flag.
        /// </remarks>
        internal override void Execute()
        {
            this.Machine.InterruptFlag = true;
        }
    }
}
