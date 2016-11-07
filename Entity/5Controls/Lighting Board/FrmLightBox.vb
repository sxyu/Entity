/*
 * Button mixin- creates 3d-ish button effect with correct
 * highlights/shadows, based on a base color.
 */
html {
  background: #f1f1f1; }

/* Links */
a {
  color: #0074a2; }
  a:hover, a:active, a:focus {
    color: #0099d5; }

#media-upload a.del-link:hover, div.dashboard-widget-submit input:hover, .subsubsub a:hover, .subsubsub a.current:hover {
  color: #0099d5; }

/* Forms */
input[type=checkbox]:checked:before {
  color: #523f6d; }

input[type=radio]:checked:before {
  background: #523f6d; }

.wp-core-ui input[type="reset"]:hover, .wp-core-ui input[type="reset"]:active {
  color: #0099d5; }

/* Core UI */
.wp-core-ui .button-primar