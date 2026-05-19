import { Link, useLocation } from 'react-router-dom';
import { motion } from 'motion/react';
import { Gamepad2, Info, Home as HomeIcon } from 'lucide-react';

export default function Navbar() {
  const location = useLocation();

  const links = [
    { name: 'Front Page', path: '/', icon: HomeIcon },
    { name: 'Game Page', path: '/game', icon: Gamepad2 },
    { name: 'About', path: '/about', icon: Info },
  ];

  return (
    <nav className="fixed top-0 left-0 right-0 z-50 bg-[#05070a]/80 backdrop-blur-md border-b border-white/10 h-20">
      <div className="max-w-7xl mx-auto px-6 h-full">
        <div className="flex items-center justify-between h-full">
          <Link to="/" className="flex items-center gap-2 group">
            <div className="flex items-center gap-1.5 translate-y-0.5">
              <div className="w-6 h-6 bg-brand-sky rounded-sm rotate-45"></div>
              <div className="w-6 h-6 bg-brand-amber rounded-full -ml-3.5 border-2 border-[#05070a]"></div>
            </div>
            <span className="ml-3 font-serif italic font-bold text-2xl tracking-tighter text-white">
              BestFriends!
            </span>
          </Link>

          <div className="flex gap-10">
            {links.map((link) => {
              const isActive = location.pathname === link.path;

              return (
                <Link
                  key={link.path}
                  to={link.path}
                  className={`text-sm uppercase tracking-[0.2em] font-medium transition-colors hover:text-white ${
                    isActive ? 'text-brand-sky' : 'text-slate-400'
                  }`}
                >
                  <span className="relative pb-1">
                    {link.name}
                    {isActive && (
                      <motion.div
                        layoutId="nav-underline"
                        className="absolute bottom-0 left-0 right-0 h-0.5 bg-brand-sky"
                        initial={false}
                      />
                    )}
                  </span>
                </Link>
              );
            })}
          </div>

          <Link
            to="/game"
            className="px-6 py-2.5 bg-white text-black text-[10px] font-bold uppercase tracking-widest hover:bg-brand-sky transition-colors shadow-sm"
          >
            Play Web Build
          </Link>
        </div>
      </div>
    </nav>
  );
}
