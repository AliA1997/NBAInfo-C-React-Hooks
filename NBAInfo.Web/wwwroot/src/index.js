import React from 'react';
import { render } from 'react-dom';
import App from './components/App';
import md5 from 'md5';

const accessToken = md5('tuff');

render(<App accessToken={accessToken} />, document.getElementById('root'));