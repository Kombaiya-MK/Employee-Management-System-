
import './App.css';
import Navbar from './components/Navbar'
import { BrowserRouter,Route,Routes } from 'react-router-dom';
import Home from './components/Home';
import AddEmployees from './components/AddEmployees';
import UpdateEmployees from './components/UpdateEmployees';
import 'bootstrap/dist/css/bootstrap.css';

function App() {
  return (
    <BrowserRouter>
        <Navbar/>
        <Routes>
        <Route path='/' element={<Home/>}/>
        <Route path='create' element={<AddEmployees/>}/>
        <Route path='list' element={<UpdateEmployees/>}/>
        </Routes>
   
      </BrowserRouter>
  );
}

export default App;
