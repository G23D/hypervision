PAParticleField v1.3

Author: Mark Hogan, mark@popupasylum.co.uk, @markeahogan, http://www.popupasylum.co.uk
Product Page: http://www.popupasylum.co.uk/paparticlefield
Documentation/User Guide: http://www.popupasylum.co.uk/paparticlefield/documentation

GETTING STARTED

- After importing PAParticleField, go to "GameObject > Create Other > PA Particle Field" to create a new field
- Check out the scenes in the "Demos" folder to see some examples
- Use the links below or the "?" buttons on the PAParticleField Inspector for documentation

HISTROY
29/09/2016 v1.3 Restructured shader with Simulate() function, added custom generator support, added custom rotation axis for mesh particles, added fog support
25/05/2016 v1.27 Added Simulate method, fixed Turbulence dropdown not showing simplex modes in Unity 5
18/04/2016 v1.261 Fixed material leak in editor
11/04/2016 v1.26 Added particleCountMask for billboards for reducing visible particle count without regenerating the mesh, optimized shaders, changed mesh data structure to improve precision (may require one time mesh regeneration), Unity 4.x mesh default shader in no longer a surface shader, fallback to sine noise on 4.x
06/04/2016 v1.254 Fallback to sin based pseudo noise on mobile with lighting, readded LIGHTING_ON keyword
01/04/2016 v1.253 Fallback to sin based pseudo noise on shader model 2.0, use dummy keywords on Unity 5
29/03/2016 v1.252 Fixed Unlitmesh shaderin 4.x, Fixed Speed/Size variations not causing a mesh rebuild, all demo scripts are now in PA.ParticleField.Samples namespace
18/03/2016 v1.251 Bugfixes, added UnlitMesh shader, uses PropertyIDs instead of names
18/03/2016 v1.25 Added turbulence, reduced shader keywords, reworked serialization for better prefab handling, better rotation on mesh particles
11/02/2015 v1.24 Fixed bug where cache was rebuilt unnecessarily, dont serialize cache in editor if "Rebuild" is ticked
15/12/2015 v1.23 Fixed bug in billboard AnimatedRows and added AnimatedRow support to mesh particles
02/12/2015 v1.22 Fixed bug in render bounds on mesh paritcles, added Local With Deltas simulation space, added Clear Cache option
12/09/2015 v1.21 Reduced memory by removing superfluous multi_compiles
19/08/2015 v1.2 Added Mesh Particles
03/06/2015 v1.12 Fixed bug in LocalSpace shaders, fields can share materials, Added Exclusion Zone Anchor Override
29/05/2015 v1.11 Fixed bug in Exclusion Zone, better Custom Vertex Program support, Added Bokeh and Custom Vertex Program Demos
22/05/2015 v1.1 Added Exclusion Zones, Clip safe and custom material support
05/05/2015 v1.02 Fixed bug in cutoff shader
20/04/2015 v1.01 Fixed Bug when duplicating field, new demo UI, better edge threshold inspector
25/03/2015 v1.0 release