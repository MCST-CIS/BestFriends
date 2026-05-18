import { Routes, Route, useLocation } from 'react-router-dom';
import { AnimatePresence, motion } from 'motion/react';
import Navbar from '../components/Navbar';
import Home from '../pages/Home';
import Game from '../pages/Game';
import About from '../pages/About';

export default function Layout() {
  const location = useLocation();

  return (
    <div className="min-h-screen bg-[#050505] text-white font-sans selection:bg-blue-500/30 selection:text-blue-200">
      <Navbar />
      <main className="pt-16">
        <AnimatePresence mode="wait">
          <motion.div
            key={location.pathname}
            initial={{ opacity: 0, y: 10 }}
            animate={{ opacity: 1, y: 0 }}
            exit={{ opacity: 0, y: -10 }}
            transition={{ duration: 0.3, ease: "easeOut" }}
          >
            <Routes location={location}>
              <Route path="/" element={<Home />} />
              <Route path="/game" element={<Game />} />
              <Route path="/about" element={<About />} />
            </Routes>
          </motion.div>
        </AnimatePresence>
      </main>
      
      <footer className="py-12 border-t border-white/5 mt-20 text-center">
        <div className="max-w-7xl mx-auto px-4">
          <p className="text-gray-500 text-sm">
            2026 BestFriends Team. Built with ❤️ for the CompSci Academy.
          </p>
        </div>
      </footer>
    </div>
  );
}
