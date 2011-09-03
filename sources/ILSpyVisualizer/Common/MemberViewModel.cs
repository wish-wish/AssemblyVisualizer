﻿// Copyright 2011 Denis Markelov
// This code is distributed under Microsoft Public License 
// (for details please see \docs\Ms-PL)

using System.Windows.Media;
using ILSpyVisualizer.Infrastructure;
using Mono.Cecil;
using System.Windows.Input;
using ICSharpCode.ILSpy;

namespace ILSpyVisualizer.Common
{
	abstract class MemberViewModel : ViewModelBase
	{
		public abstract ImageSource Icon { get; }
		public abstract string Text { get; }
        public ICommand JumpCommand { get; private set; }

        public MemberViewModel()
        {
            JumpCommand = new DelegateCommand(JumpCommandHandler);
        }

        public virtual bool IsVirtual
        {
            get
            {
                return false;
            }
        }

        public virtual bool IsOverridden
        {
            get
            {
                return false;
            }
        }

        public abstract MemberReference MemberReference { get; }

        public abstract bool IsPublic { get; }
        public abstract bool IsProtected { get; }
        public abstract bool IsInternal { get; }
        public abstract bool IsPrivate { get; }
        public abstract bool IsProtectedInternal { get; }   

        private void JumpCommandHandler()
        {
            MainWindow.Instance.JumpToReference(MemberReference);
        }
	}
}
